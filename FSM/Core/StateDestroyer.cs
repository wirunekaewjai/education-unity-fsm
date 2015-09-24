using System;
using System.Collections.Generic;
using UnityEngine;

namespace Devdayo.FSM.Core
{
    internal sealed class StateDestroyer
    {
        private List<Action> methods = new List<Action>();

        internal void Destroy()
        {
            foreach (var method in methods)
            {
                if (null != method)
                    method();
            }
        }

        public void Add(Action destroyMethod)
        {
            methods.Add(destroyMethod);
        }

        public void Remove(Action destroyMethod)
        {
            methods.Remove(destroyMethod);
        }
    }
}
