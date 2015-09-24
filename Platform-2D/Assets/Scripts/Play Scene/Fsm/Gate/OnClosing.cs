using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Gate
{
	public class OnClosing : StateBehaviour<GateFSM>
    {
        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (!other.CompareTag(Tag.Player))
                return;
            
            int coin = CoinManager.Instance.coin;
            if (coin < Owner.requireCoins)
                return;

            Owner.tween.MoveTo(0);

            Machine.Go<OnOpening>();
        }
    }
}
