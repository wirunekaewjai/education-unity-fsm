using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Player
{
    public class OnLadder : StateBehaviour<PlayerFSM>
    {
        protected override void OnEnter()
        {
            base.OnEnter();

            Owner.gravityScale = Owner.rigidbody.gravityScale;
            Owner.rigidbody.gravityScale = 0;
        }

        protected override void OnExit()
        {
            base.OnExit();

            Owner.rigidbody.gravityScale = Owner.gravityScale;
            Owner.gravityScale = 0;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            Owner.UpdateHorizontal();
            Owner.UpdateVertical();
            Owner.Jump(false);
        }

        public override void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);

            if (other.gameObject.CompareTag(Tag.Ladder))
            {
                Machine.Go<OnSoar>();
            }
        }
    }
}
