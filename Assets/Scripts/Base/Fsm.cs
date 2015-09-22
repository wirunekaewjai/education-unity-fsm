// Contain "MonoBehaviour" Class
using UnityEngine;

// Contain "Dictionary" Class
using System.Collections.Generic;

// Contain "Type" Class
using System;

namespace Devdayo
{
    // Do not derived. Just create instance and use it.
    public sealed class Fsm
    {
        // Keep every state instances here !!!.
        // Use Dictionary to seperate instance by type.
        private readonly Dictionary<Type, FsmState> states = new Dictionary<Type, FsmState>();

        // Keep current state.
        public FsmState currentState { get; private set; }

        // Keep owner of Fsm.
        public MonoBehaviour owner { get; private set; }
        public GameObject gameObject { get { return owner.gameObject; } }

        // Construct
        public Fsm(MonoBehaviour owner)
        {
            this.owner = owner;
        }

        // Exit Current State & Clear Dictionary
        public void Destroy()
        {
            // false : if you never called "Go<T>"
            if (null != currentState)
            {
                // Should Unsubscribe events before exit this state.
                currentState.OnUnsubscribe();

                // Exit this state
                currentState.OnExit();
            }

            // Clear !!!
            states.Clear();
        }

        // Change State by <T> (T must inherit from FsmState)
        // You can use T, A, B, K, V or every words.
        public void Go<T>() where T : FsmState
        {
            // true : if you have change to same current state.
            if (null != currentState && currentState is T)
                return;

            // Start Change state process.
            owner.StartCoroutine(OnChangeState<T>());
        }

        // Called from StartCoroutine.
        private System.Collections.IEnumerator OnChangeState<T>() where T : FsmState
        {
            // Waiting. . .
            yield return new WaitForEndOfFrame();

            // true : when change state in second time.
            if (null != currentState)
            {
                // Should Unsubscribe events before exit this state.
                currentState.OnUnsubscribe();

                // Exit this state
                currentState.OnExit();
            }

            // GetType of T (State Type).
            Type type = typeof(T);

            // true : if you not ever travelling to this state.
            if (!states.ContainsKey(type))
            {
                // Create state instance by Type and pass "this" as argument.
                states[type] = FsmState.Create<T>(this);
            }

            // Get state instance
            currentState = states[type];

            // Wait ! Wait ! Wait ! Again.
            yield return new WaitForEndOfFrame();

            // Subscribe Events
            currentState.OnSubscribe();

            // Your State is Begin !!!
            currentState.OnEnter();
        }
    }

}