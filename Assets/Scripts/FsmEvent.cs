using UnityEngine;
using System;

// Base Event Class
public class FsmEvent : MonoBehaviour
{
    protected Action subscribers;

    protected void Notify()
    {
        if (null != subscribers)
            subscribers();
    }

    // Subscribe by Type
    public static void Subscribe<T>(GameObject target, Action action) where T : FsmEvent
    {
        var c = target.GetComponent<T>();

        if (null == c)
            c = target.AddComponent<T>();

        // On Subscribe
        c.subscribers += action;
    }

    // Unsubscribe by Type
    public static void Unsubscribe<T>(GameObject target, Action action) where T : FsmEvent
    {
        var c = target.GetComponent<T>();

        // On Unsubscribe
        c.subscribers -= action;
    }
}

public class FsmEvent<C> : MonoBehaviour
{
    protected Action<C> subscribers;

    protected void Notify(C c)
    {
        if (null != subscribers)
            subscribers(c);
    }

    public static void Subscribe<T>(GameObject target, Action<C> action) where T : FsmEvent<C>
    {
        var c = target.GetComponent<T>();

        if (null == c)
            c = target.AddComponent<T>();

        c.subscribers += action;
    }

    public static void Unsubscribe<T>(GameObject target, Action<C> action) where T : FsmEvent<C>
    {
        var c = target.GetComponent<T>();

        c.subscribers -= action;
    }
}
