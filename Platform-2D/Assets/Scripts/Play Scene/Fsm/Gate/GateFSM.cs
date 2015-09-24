using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Gate
{
	[RequireComponent(typeof(Tween))]
	public class GateFSM : MonoBehaviour
    {
        private StateMachine<GateFSM> machine;

        internal Tween tween;

		public int requireCoins = 1;
		
		void Awake()
		{
			tween = GetComponent<Tween>();	
			tween.autoPlay = false;

            machine = new StateMachine<GateFSM>(this);
        }
		
		void Start()
		{
            machine.Go<OnClosed>();
		}
        
	}
}