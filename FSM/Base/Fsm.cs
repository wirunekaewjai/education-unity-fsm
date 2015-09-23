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

        // State change locker
		private Type currentType;
		
		// Keep owner of Fsm.
		private MonoBehaviour owner;

        // Keep current state.
        public FsmState currentState { get; private set; }

		// Get Owner by your type
		public T GetOwner<T>() where T : MonoBehaviour
		{
			// Casting type and return it.
			return (T) owner;
		}

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
                // Exit this state
                currentState.Exit();
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
            
            // true : when someone has queued.
            if (null != currentType)
                return;

            // GetType of T (State Type).
            currentType = typeof(T);

            // true : when change state in second time.
            if (null != currentState)
            {
                // Exit this state
                currentState.Exit();
            }

            // Start Change state process.
            FsmTask.Instance.Enqueue(OnChangeState);
        }

        // Called from StartCoroutine.
        private void OnChangeState()
        {
            // true : if you not ever travelling to this state.
            if (!states.ContainsKey(currentType))
            {
				// Create Instance by Type
				currentState = Activator.CreateInstance(currentType) as FsmState;

				// Call Creation Logic
				currentState.Create(this);

                // Create state instance by Type and pass "this" as argument.
				states[currentType] = currentState;
            }
			else
			{
				// Get state instance
				currentState = states[currentType];
			}

            // Unlocked
            currentType = null;

            // Your State is Begin !!!
            currentState.Enter();
        }
    }

}