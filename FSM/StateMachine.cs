// Contain "Type" Class
using System;

using UnityEngine;

using Devdayo.FSM.Core;

using System.Collections.Generic;

namespace Devdayo.FSM
{
    public sealed class StateMachine<A> where A : MonoBehaviour
    {
        // Keep every state instances here !!!.
        // Use Dictionary to seperate instance by type.
        // private readonly Dictionary<Type, State<A>> states = new Dictionary<Type, State<A>>();


        // State change locker
        private Type currentType;

        // Keep current state.
        public State<A> CurrentState { get; private set; }

        // Keep owner of Fsm.
        public A Owner { get; private set; }
        
        // Construct
        public StateMachine(A owner)
        {
            this.Owner = owner;

            Instance.Destroyer.Add(Destroy);
        }

        // Exit Current State & Clear Dictionary
        internal void Destroy()
        {
            // false : if you never called "Go<T>"
            if (null != CurrentState)
            {
                // Exit this state
                CurrentState.Destroy();
            }
        }

        // Change State by <T> (T must inherit from FsmState)
        // You can use T, A, B, K, V or every words.
        public void Go<B>() where B : State<A>
        {
            // true : if you have change to same current state.
            if (null != CurrentState && CurrentState is B)
                return;

            // true : when someone has queued.
            if (null != currentType)
                return;

            // GetType of T (State Type).
            currentType = typeof(B);

            // true : when change state in second time.
            if (null != CurrentState)
            {
                // Exit this state
                CurrentState.Exit();
            }

            // Start Change state process.
            Instance.Changer.Enqueue(OnChangeState);
        }

        // Called from StartCoroutine.
        private void OnChangeState()
        {
            /*
            // true : if you not ever travelling to this state.
            if (!states.ContainsKey(currentType))
            {
                // Create Instance by Type
                CurrentState = Activator.CreateInstance(currentType) as State<A>;

                // Create state instance by Type and pass "this" as argument.
                states[currentType] = CurrentState;
            }
            else
            {
                // Get state instance
                CurrentState = states[currentType];
            }

            // Unlocked
            currentType = null;

            */
            State<A> nextState = Instance.Creator.Dequeue<A>(currentType);

            // Unlocked
            currentType = null;

            // Setup new current state
            CurrentState = nextState;
            
            // Your State is Begin !!!
            CurrentState.Enter(this);
        }
    }
}
