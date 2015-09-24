using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Gate
{
    public class OnOpening : StateBehaviour<GateFSM>
    {
        public override void OnUpdate()
        {
            base.OnUpdate();

            int index = Owner.tween.currentIndex;
            if (index == 1)
                return;

            Machine.Go<OnOpened>();
        }

        public override void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);

            if (!other.CompareTag(Tag.Player))
                return;

            Owner.tween.MoveTo(1);

            Machine.Go<OnClosing>();
        }
    }
}
