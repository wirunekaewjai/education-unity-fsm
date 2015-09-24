using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Player
{
    public class OnSoar : StateBehaviour<PlayerFSM>
    {
        protected override void OnEnter()
        {
            base.OnEnter();

            Owner.animator.SetBool("Soaring", true);
        }

        protected override void OnExit()
        {
            base.OnExit();

            Owner.animator.SetBool("Soaring", false);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            Owner.UpdateHorizontal();
        }

        public override void OnCollisionEnter2D(Collision2D other)
        {
            base.OnCollisionEnter2D(other);

            if (other.gameObject.CompareTag(Tag.Bot))
            {
                Vector3 p1 = Owner.transform.position;
                Vector3 p2 = other.transform.position;

                Vector3 direction = (p1 - p2).normalized;
                float angle = Vector3.Angle(Vector3.up, direction);

                if (angle > 30f)
                    return;

                Owner.Jump(true);
            }
        }

        public override void OnCollisionStay2D(Collision2D other)
        {
            base.OnCollisionStay2D(other);

            if (other.gameObject.CompareTag(Tag.Elevator))
            {
                Machine.Go<OnElevator>();
            }
            else if (other.gameObject.CompareTag(Tag.Platform))
            {
                float vy = Owner.rigidbody.velocity.y;
                if (Mathf.Abs(vy) < Mathf.Epsilon)
                {
                    Machine.Go<OnGround>();
                }
            }
            else if (other.gameObject.CompareTag(Tag.Bot))
            {
                Vector3 p1 = Owner.transform.position;
                Vector3 p2 = other.transform.position;

                Vector3 direction = (p1 - p2).normalized;
                float angle = Vector3.Angle(Vector3.up, direction);

                if (angle <= 30f)
                    return;

                // Die !!!
                Owner.rigidbody.velocity = Physics2D.gravity;

                Machine.Go<OnFlop>();
            }
        }

        public override void OnTriggerStay2D(Collider2D other)
        {
            base.OnTriggerStay2D(other);

            if (other.gameObject.CompareTag(Tag.Ladder))
            {
                Machine.Go<OnLadder>();
            }
        }

    }
}
