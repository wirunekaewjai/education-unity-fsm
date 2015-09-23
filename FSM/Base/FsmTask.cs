using UnityEngine;
using System.Collections.Generic;
using System;

namespace Devdayo
{
    // I'm a hard-worker
    internal class FsmTask : Singleton<FsmTask>
    {
        // Limit of iteration in one frame.
        private const int Limit = 100;

        // My queues.
        private readonly Queue<Action> queues = new Queue<Action>();

        // Update routine.
        private void FixedUpdate()
        {
            // We can't do all queue in one time. 
            for (int i = 0; i < Limit && queues.Count > 0; ++i)
            {
                // Looking for queue.
                Action action = queues.Dequeue();
                
                // Do it !!!
                action();
            }

            // Get some rest and wating for a new called.
        }

        // Can enqueue any tasks you want !!!
        public void Enqueue(Action action)
        {
            queues.Enqueue(action);
        }
    }
}