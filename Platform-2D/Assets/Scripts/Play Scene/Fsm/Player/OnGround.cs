using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Player
{
    public class OnGround : StateBehaviour<PlayerFSM>
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            Owner.UpdateHorizontal();
            Owner.Jump(false);
        }

        public override void OnCollisionStay2D(Collision2D other)
        {
            base.OnCollisionStay2D(other);

            if (other.gameObject.CompareTag(Tag.Bot))
            {
                Machine.Go<OnFlop>();
            }
        }

        public override void OnCollisionExit2D(Collision2D other)
        {
            base.OnCollisionExit2D(other);

            if (other.gameObject.CompareTag(Tag.Platform))
            {
                Machine.Go<OnSoar>();
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
