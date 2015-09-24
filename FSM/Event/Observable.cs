using System;
using UnityEngine;
using Devdayo.FSM.Core;

namespace Devdayo.FSM.Event
{
    // 0 Parameter
    public class Observable : MonoBehaviour
    {
        private Action callback;
        private int count = 0;

        protected void Notify()
        {
            if (null != callback)
                callback();
        }

        private void OnSelfDestroy()
        {
            Destroy(this);
        }

        // Subscribe by Type
        public static void Subscribe<T>(GameObject target, Method method) where T : Observable
        {
            var c = target.GetComponent<T>();

            if (null == c)
            {
                c = target.AddComponent<T>();
            }

            // On Subscribe
            c.callback += Instance.Method.Get(method);
            c.CancelInvoke("OnSelfDestroy");
            c.count++;
        }

        // Unsubscribe by Type
        public static void Unsubscribe<T>(GameObject target, Method method) where T : Observable
        {
            var c = target.GetComponent<T>();

            if(null != c)
            {
                // On Unsubscribe
                c.callback -= Instance.Method.Remove(method);
                c.count--;

                if (c.count == 0)
                    c.Invoke("OnSelfDestroy", 10);
            }
        }
    }

    // 1 Parameter
    public class Observable<A> : MonoBehaviour
    {
        private Action<A> callback;
        private int count = 0;

        protected void Notify(A a)
        {
            if (null != callback)
                callback(a);
        }

        private void OnSelfDestroy()
        {
            Destroy(this);
        }

        // Subscribe by Type
        public static void Subscribe<T>(GameObject target, Method method) where T : Observable<A>
        {
            var c = target.GetComponent<T>();

            if (null == c)
            {
                c = target.AddComponent<T>();
            }
            
            // On Subscribe
            c.callback += Instance.Method.Get<A>(method);
            c.CancelInvoke("OnSelfDestroy");
            c.count++;
        }

        // Unsubscribe by Type
        public static void Unsubscribe<T>(GameObject target, Method method) where T : Observable<A>
        {
            var c = target.GetComponent<T>();

            if (null != c)
            {
                // On Unsubscribe
                c.callback -= Instance.Method.Remove<A>(method);
                c.count--;

                if (c.count == 0)
                    c.Invoke("OnSelfDestroy", 10);
            }
        }
    }

    // 2 Parameter
    public class Observable<A, B> : MonoBehaviour
    {
        private Action<A, B> callback;
        private int count = 0;
        
        protected void Notify(A a, B b)
        {
            if (null != callback)
                callback(a, b);
        }

        private void OnSelfDestroy()
        {
            Destroy(this);
        }

        // Subscribe by Type
        public static void Subscribe<T>(GameObject target, Method method) where T : Observable<A, B>
        {
            var c = target.GetComponent<T>();

            if (null == c)
            {
                c = target.AddComponent<T>();
            }
            
            // On Subscribe
            c.callback += Instance.Method.Get<A, B>(method);
            c.CancelInvoke("OnSelfDestroy");
            c.count++;
        }

        // Unsubscribe by Type
        public static void Unsubscribe<T>(GameObject target, Method method) where T : Observable<A, B>
        {
            var c = target.GetComponent<T>();

            if (null != c)
            {
                // On Unsubscribe
                c.callback -= Instance.Method.Remove<A, B>(method);
                c.count--;

                if(c.count == 0)
                    c.Invoke("OnSelfDestroy", 10);
            }
        }
    }
}
