using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Player
{
    public class OnElevator : StateBehaviour<PlayerFSM>
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            Owner.UpdateHorizontal();
            Owner.Jump(false);
        }

        public override void OnCollisionEnter2D(Collision2D other)
        {
            base.OnCollisionEnter2D(other);

            if (other.gameObject.CompareTag(Tag.Bot))
            {
                Vector3 direction = other.relativeVelocity.normalized;
                float angle = Vector3.Angle(Vector3.down, direction);

                // Bounce Up (Jump) or Die
                if (angle >= 45f)
                {
                    Machine.Go<OnFlop>();
                }
            }
        }

        public override void OnCollisionStay2D(Collision2D other)
        {
            base.OnCollisionStay2D(other);

            if (other.gameObject.CompareTag(Tag.Platform))
            {
                float vy = Owner.rigidbody.velocity.y;
                if (Mathf.Abs(vy) < Mathf.Epsilon)
                {
                    Machine.Go<OnGround>();
                }
            }
        }

        public override void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);

            if (other.gameObject.CompareTag(Tag.Elevator))
            {
                Machine.Go<OnSoar>();
            }
        }
    }
}
