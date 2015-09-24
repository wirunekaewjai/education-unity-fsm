using UnityEngine;
using System.Collections;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Player
{
    public class OnFlop : StateBehaviour<PlayerFSM>
    {
        protected override void OnEnter()
        {
            base.OnEnter();

            Owner.animator.SetTrigger("Flopping");

            Owner.boxCollider.enabled = false;
            Owner.polyCollider.enabled = true;

            Owner.gameObject.layer = LayerMask.NameToLayer("Dead Man");
        }

        protected override void OnExit()
        {
            base.OnExit();

            Owner.rigidbody.Sleep();
        }

        public override void OnCollisionStay2D(Collision2D other)
        {
            base.OnCollisionStay2D(other);

            if (other.gameObject.CompareTag(Tag.Platform) ||
                other.gameObject.CompareTag(Tag.Elevator) ||
                other.gameObject.CompareTag(Tag.Ladder))
            {
                Owner.rigidbody.Sleep();

                Owner.boxCollider.enabled = false;
                Owner.polyCollider.enabled = false;

                Machine.Go<OnDied>();
            }
        }
    }
}
