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
            FsmState t = Activator.CreateInstance(type) as FsmState;

            // Set Target Fsm
            t.fsm = fsm;

            // Call sub-class custom logic while instnace creating.
            t.OnCreate(fsm);

            // Return to Fsm
            return t;
        }

        // Instance Properties (Received data from Fsm)
        public Fsm fsm { get; private set; }
        public GameObject gameObject { get { return fsm.gameObject; } }
        
        public T GetOwner<T>() where T : MonoBehaviour
        {
            return (T)fsm.owner;
        }

        // Subscribe helper
        protected void Subscribe<T>(Action a) where T : FsmEvent
        {
            FsmEvent.Subscribe<T>(gameObject, a);
        }
        protected void Subscribe<T>(Action a, GameObject observable) where T : FsmEvent
        {
            FsmEvent.Subscribe<T>(observable, a);
        }
        protected void Subscribe<T, A>(Action<A> a) where T : FsmEvent<A>
        {
            FsmEvent<A>.Subscribe<T>(gameObject, a);
        }
        protected void Subscribe<T, A>(Action<A> a, GameObject observable) where T : FsmEvent<A>
        {
            FsmEvent<A>.Subscribe<T>(observable, a);
        }
        protected void Subscribe<T, A, B>(Action<A, B> a) where T : FsmEvent<A, B>
        {
            FsmEvent<A, B>.Subscribe<T>(gameObject, a);
        }
        protected void Subscribe<T, A, B>(Action<A, B> a, GameObject observable) where T : FsmEvent<A, B>
        {
            FsmEvent<A, B>.Subscribe<T>(observable, a);
        }

        // Unsubscribe helper
        protected void Unsubscribe<T>(Action a) where T : FsmEvent
        {
            FsmEvent.Unsubscribe<T>(gameObject, a);
        }
        protected void Unsubscribe<T>(Action a, GameObject observable) where T : FsmEvent
        {
            FsmEvent.Unsubscribe<T>(observable, a);
        }
        protected void Unsubscribe<T, A>(Action<A> a) where T : FsmEvent<A>
        {
            FsmEvent<A>.Unsubscribe<T>(gameObject, a);
        }
        protected void Unsubscribe<T, A>(Action<A> a, GameObject observable) where T : FsmEvent<A>
        {
            FsmEvent<A>.Unsubscribe<T>(observable, a);
        }
        protected void Unsubscribe<T, A, B>(Action<A, B> a) where T : FsmEvent<A, B>
        {
            FsmEvent<A, B>.Unsubscribe<T>(gameObject, a);
        }
        protected void Unsubscribe<T, A, B>(Action<A, B> a, GameObject observable) where T : FsmEvent<A, B>
        {
            FsmEvent<A, B>.Unsubscribe<T>(observable, a);
        }

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
