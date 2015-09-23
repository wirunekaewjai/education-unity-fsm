// Contain "GameObject" Class
using UnityEngine;

// Contain "Activator" Class
using System;

namespace Devdayo
{
    // Light-weight Fsm State.
    // Please derived this class if you want to customize your subscription.
    public abstract class FsmState : FsmObserver
    {
        // Instance Properties (Received data from Fsm)
        public Fsm fsm { get; private set; }

		// Get Owner GameObject
        public GameObject gameObject { get { return fsm.GetOwner<MonoBehaviour>().gameObject; } }

		public void Create(Fsm fsm)
		{
			// Set Target Fsm
			this.fsm = fsm;

			// Called your custom create logic
			OnCreate();
		}

		public void Enter()
		{
			// Should Subscribe events before enter this state.
			Subscribe();
			
			// Called your custom enter logic
			OnEnter();
		}

		public void Exit()
		{
			// Should Unsubscribe events before exit this state.
			Unsubscribe();
			
			// Called your custom exit logic
			OnExit();
		}

		// Virtual Methods
        // Override it to custom your own logic while instance creating.
        protected virtual void OnCreate() 
		{

		}

		// You can override if you want to create your own logic while enter and exit.
        protected virtual void OnEnter()
		{

		}
		
		protected virtual void OnExit() 
		{

		}
    }
}
