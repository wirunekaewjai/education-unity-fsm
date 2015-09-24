using System;
using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Bot
{
    public class OnFlop : StateBehaviour<BotFSM>
    {
        protected override void OnEnter()
        {
            base.OnEnter();

            Owner.animator.SetTrigger("Flopping");

            Owner.boxCollider.enabled = false;
            Owner.polyCollider.enabled = true;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            Rigidbody2D rb = Owner.rigidbody;

            if (Mathf.Abs(rb.velocity.y) > Mathf.Epsilon)
                return;

            rb.gravityScale = 0;
            rb.Sleep();

            Owner.boxCollider.enabled = false;
            Owner.polyCollider.enabled = false;

            Machine.Go<OnDied>();
        }
    }
}
