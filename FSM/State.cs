using System;

// Contain "MonoBehaviour" Class
using UnityEngine;

// Contain "Observer" Class
using Devdayo.FSM.Event;
using Devdayo.FSM.Core;

namespace Devdayo.FSM
{
    // Light-weight Fsm State.
    // Please derived this class if you want to customize your subscription.
    public abstract class State<A> : Observer where A : MonoBehaviour
    {
        // Current State Machine
        protected internal StateMachine<A> Machine { get; private set; }
        
        // Get Owner Object by Type
        protected internal A Owner { get { return Machine.Owner; } }

        /* 
            Please Remember !!!
            - Do not declare variable in your derived class because this state will reuse by many owner. -
        */

        // Construct and Call OnCreate
        public State()
        {
            OnCreate();
        }

        // Only instance in same namespace can call this method
        internal void Enter(StateMachine<A> newMachine)
        {
            this.Machine = newMachine;

            // Should Subscribe events before enter this state.
            OnSubscribe();

            // Called your custom enter logic
            OnEnter();
        }

        // Only instance in same namespace can call this method
        internal void Exit()
        {
            // Should Unsubscribe events before exit this state.
            OnUnsubscribe();

            // Called your custom exit logic
            OnExit();
        }

        internal void Destroy()
        {
            // Shouldn't Unsubscribe events in the method because managers are deleted.
            // Called your custom exit logic
            OnExit();
        }

        // Virtual Methods
        // Override it to custom your own logic while instance creating.
        protected virtual void OnCreate() { }

        // You can override if you want to create your own logic while enter and exit.
        protected virtual void OnEnter() { }
        protected virtual void OnExit() { }
        
        protected void Subscribe(StateEvent e, GameObject target, Action delegateMethod)
        {
            string name = delegateMethod.Method.Name;
            object owner = delegateMethod.Target;

            Method method = new Method(name, owner);
            Subscribe(e, target, method);
        }

        protected void Unsubscribe(StateEvent e, GameObject target, Action action)
        {
            string name = action.Method.Name;
            object owner = action.Target;

            Method method = new Method(name, owner);
            Unsubscribe(e, target, method);
        }

        protected void Subscribe<I>(StateEvent e, GameObject target, Action<I> action)
        {
            string name = action.Method.Name;
            object owner = action.Target;

            Method method = new Method(name, owner);
            Subscribe(e, target, method);
        }

        protected void Unsubscribe<I>(StateEvent e, GameObject target, Action<I> action)
        {
            string name = action.Method.Name;
            object owner = action.Target;

            Method method = new Method(name, owner);
            Unsubscribe(e, target, method);
        }

        protected void Subscribe<I, J>(StateEvent e, GameObject target, Action<I, J> action)
        {
            string name = action.Method.Name;
            object owner = action.Target;

            Method method = new Method(name, owner);
            Subscribe(e, target, method);
        }

        protected void Unsubscribe<I, J>(StateEvent e, GameObject target, Action<I, J> action)
        {
            string name = action.Method.Name;
            object owner = action.Target;

            Method method = new Method(name, owner);
            Unsubscribe(e, target, method);
        }

        /*
        public override void Subscribe(StateEvent e, Method method)
        {
            base.Subscribe(e, method);

            GameObject target = Owner.gameObject;
            base.Subscribe(e, target, method);
        }

        public override void Unsubscribe(StateEvent e, Method method)
        {
            base.Unsubscribe(e, method);

            GameObject target = Owner.gameObject;
            base.Unsubscribe(e, target, method);
        }
        */
    }
}
