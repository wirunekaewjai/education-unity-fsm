using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Bot
{
    public class OnMove : StateBehaviour<BotFSM>
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            Rigidbody2D rb = Owner.rigidbody;
            Vector2 velocity = rb.velocity;

            float h = Mathf.Abs(velocity.x);

            // Apply Running Animation | Idle
            Owner.animator.SetBool("Running", h > 0.1f);

            // Moving ?
            if (velocity.x == 0)
                return;

            // Calculate Face Direction
            Vector3 scale = Owner.transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(velocity.x);

            // Flip Face Direction
            Owner.transform.localScale = scale;
        }

        public override void OnCollisionEnter2D(Collision2D other)
        {
            base.OnCollisionEnter2D(other);

            if (Owner.immortal)
                return;

            if (!other.gameObject.CompareTag(Tag.Player))
                return;

            Vector3 p1 = other.transform.position;
            Vector3 p2 = Owner.transform.position;

            Vector3 direction = (p1 - p2).normalized;
            float angle = Vector3.Angle(Vector3.up, direction);

            if (angle > 30f)
                return;

            // Flop & Died
            Owner.tween.enabled = false;

            Machine.Go<OnFlop>();
        }
    }
}
