using System;
using System.Collections.Generic;

namespace Devdayo.FSM.Core
{
    // I'm a hard-worker
    internal sealed class StateChanger
    {
        // Limit of iteration in one frame.
        private const int Limit = 100;

        // My queues.
        private readonly Queue<Action> queues = new Queue<Action>();

        // Update routine.
        internal void FixedUpdate()
        {
            // We can't do all queue in one time. 
            for (int i = 0; i < Limit && queues.Count > 0; ++i)
            {
                // Looking for queue.
                Action callback = queues.Dequeue();

                // Do it !!!
                callback();
            }

            // Get some rest and wating for a new called.
        }

        internal void Destroy()
        {
            queues.Clear();
        }

        // Can enqueue any tasks you want !!!
        public void Enqueue(Action callback)
        {
            queues.Enqueue(callback);
        }
    }
}
