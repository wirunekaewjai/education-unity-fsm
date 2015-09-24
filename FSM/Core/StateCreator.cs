using System;
using System.Collections.Generic;

using UnityEngine;

namespace Devdayo.FSM.Core
{
    internal sealed class StateCreator
    {
        // Limit a state in pool
        private const int LIMIT = 20;

        // Keep unused state in list by state type and waiting for clean up.
        private readonly Dictionary<Type, Queue<object>> pools = new Dictionary<Type, Queue<object>>();

        private MonoBehaviour behaviour;

        internal StateCreator(MonoBehaviour b)
        {
            behaviour = b;
        }

        internal void Start()
        {
            behaviour.StartCoroutine(OnUpdate());
        }

        internal void Destroy()
        {
            behaviour.StopAllCoroutines();
            pools.Clear();
        }

        private System.Collections.IEnumerator OnUpdate()
        {
            while(behaviour.enabled)
            {
                // Read State Lists
                foreach (var pool in pools.Values)
                {
                    // Empty ?
                    if(pool.Count > LIMIT)
                    {
                        // e.g., 25 - 20 = 5 then dequeue 5 ea.
                        int excess = pool.Count - LIMIT;
                        for (int i = 0; i < excess; ++i)
                        {
                            // Clean 1 ea
                            pool.Dequeue();
                        }
                    }
                }

                // Get some rest.
                yield return new WaitForSeconds(5);
            }
        }

        public void Enqueue<A>(State<A> unusedState) where A : MonoBehaviour
        {
            Type type = unusedState.GetType();

            if(!pools.ContainsKey(type))
            {
                pools[type] = new Queue<object>();
            }

            pools[type].Enqueue(unusedState);
        }

        public State<A> Dequeue<A>(Type type) where A : MonoBehaviour
        {
            if (!pools.ContainsKey(type))
            {
                pools[type] = new Queue<object>();
            }

            if (pools[type].Count == 0)
            {
                return Activator.CreateInstance(type) as State<A>;
            }

            return pools[type].Dequeue() as State<A>;
        }
    }
}
