
using UnityEngine;
using System;

namespace Devdayo
{
    // Base Event Class
    public class FsmObservable : MonoBehaviour
    {
        protected Action subscribers;

        protected void Notify()
        {
            if (null != subscribers)
                subscribers();
        }

        // Subscribe by Type
        public static void Subscribe<T>(GameObject target, Action action) where T : FsmObservable
        {
            var c = target.GetComponent<T>();

            if (null == c)
                c = target.AddComponent<T>();

            // On Subscribe
            c.subscribers += action;
        }

        // Unsubscribe by Type
        public static void Unsubscribe<T>(GameObject target, Action action) where T : FsmObservable
        {
            var c = target.GetComponent<T>();

            // On Unsubscribe
            c.subscribers -= action;
        }
    }

	public class FsmObservable<A> : MonoBehaviour
    {
        protected Action<A> subscribers;

        protected void Notify(A a)
        {
            if (null != subscribers)
                subscribers(a);
        }

        public static void Subscribe<T>(GameObject target, Action<A> action) where T : FsmObservable<A>
        {
            var a = target.GetComponent<T>();

            if (null == a)
                a = target.AddComponent<T>();

            a.subscribers += action;
        }

        public static void Unsubscribe<T>(GameObject target, Action<A> action) where T : FsmObservable<A>
        {
            var a = target.GetComponent<T>();

            a.subscribers -= action;
        }
    }


    public class FsmObservable<A, B> : MonoBehaviour
    {
        protected Action<A, B> subscribers;

        protected void Notify(A a, B b)
        {
            if (null != subscribers)
                subscribers(a, b);
        }

        public static void Subscribe<T>(GameObject target, Action<A, B> action) where T : FsmObservable<A, B>
        {
            var c = target.GetComponent<T>();

            if (null == c)
                c = target.AddComponent<T>();

            c.subscribers += action;
        }

        public static void Unsubscribe<T>(GameObject target, Action<A, B> action) where T : FsmObservable<A, B>
        {
            var c = target.GetComponent<T>();

            c.subscribers -= action;
        }
    }
}