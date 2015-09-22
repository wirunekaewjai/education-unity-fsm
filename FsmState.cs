// Contain "GameObject" Class
using UnityEngine;

// Contain "Activator" Class
using System;

namespace Devdayo
{
    // Light-weight Fsm State.
    // Please derived this class if you want to customize your subscription.
    public abstract class FsmState
    {
        // Create Child FsmState Instance and Setup Fsm Property
        // This method should called by Fsm or Sub-class of Fsm
        public static T Create<T>(Fsm fsm) where T : FsmState
        {
            // Create Instance by Type
            T t = Activator.CreateInstance<T>();

            // Set Target Fsm
            t.fsm = fsm;

            // Call sub-class custom logic while instnace creating.
            t.OnCreate(fsm);

            // Return to Fsm
            return t;
        }
		
		// Create Child FsmState Instance and Setup Fsm Property
		// This method should called by Fsm or Sub-class of Fsm
		public static FsmState Create(Fsm fsm, Type type)
		{
			// Create Instance by Type
			FsmState f = Activator.CreateInstance(type) as FsmState;
			
			// Set Target Fsm
			f.fsm = fsm;

			// Call sub-class custom logic while instnace creating.
			f.OnCreate(fsm);
			
			// Return to Fsm
			return f;
		}

        // Instance Properties (Received data from Fsm)
        public Fsm fsm { get; private set; }
        public GameObject gameObject { get { return fsm.gameObject; } }

        // Override it to custom your own logic while instance creating.
        protected virtual void OnCreate(Fsm fsm) { }

        // Subscription Methods
        // Using for Subscribe/Unsubscribe Update, Collision or Trigger Events
        public virtual void OnSubscribe() { }
        public virtual void OnUnsubscribe() { }

        // Abstract Methods
        // Every state must override this methods.
        public abstract void OnEnter();
        public abstract void OnExit();

        // Print Message
        public void print(object msg)
        {
            MonoBehaviour.print(msg);
        }
    }
}
