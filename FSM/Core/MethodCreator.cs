using System;
using System.Collections.Generic;

namespace Devdayo.FSM.Core
{
    public class MethodCreator
    {
        private readonly Dictionary<object, Dictionary<string, object>> methods = new Dictionary<object, Dictionary<string, object>>();
        
        internal void Destroy()
        {
            methods.Clear();
        }
        
        // Get Methods
        public Action Get(Method method)
        {
            object owner = method.owner;
            string name = method.name;

            if (!methods.ContainsKey(owner))
            {
                methods[owner] = new Dictionary<string, object>();
            }

            if (!methods[owner].ContainsKey(name))
            {
                methods[owner][name] = Delegate.CreateDelegate(typeof(Action), owner, name);
            }

            return methods[owner][name] as Action;
        }

        public Action<A> Get<A>(Method method)
        {
            object owner = method.owner;
            string name = method.name;

            if (!methods.ContainsKey(owner))
            {
                methods[owner] = new Dictionary<string, object>();
            }

            if (!methods[owner].ContainsKey(name))
            {
                methods[owner][name] = Delegate.CreateDelegate(typeof(Action<A>), owner, name);
            }

            return methods[owner][name] as Action<A>;
        }

        public Action<A, B> Get<A, B>(Method method)
        {
            object owner = method.owner;
            string name = method.name;

            if (!methods.ContainsKey(owner))
            {
                methods[owner] = new Dictionary<string, object>();
            }

            if (!methods[owner].ContainsKey(name))
            {
                methods[owner][name] = Delegate.CreateDelegate(typeof(Action<A, B>), owner, name);
            }

            return methods[owner][name] as Action<A, B>;
        }

        // Remove Methods
        public Action Remove(Method method)
        {
            Action action = Get(method);

            methods[method.owner].Remove(method.name);

            return action;
        }
        
        public Action<A> Remove<A>(Method method)
        {
            Action<A> action = Get<A>(method);

            methods[method.owner].Remove(method.name);

            return action;
        }

        public Action<A, B> Remove<A, B>(Method method)
        {
            Action<A, B> action = Get<A, B>(method);

            methods[method.owner].Remove(method.name);

            return action;
        }
    }
}
