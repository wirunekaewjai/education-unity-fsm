using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class WillRenderObject : FsmEvent
    {
        void OnWillRenderObject()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class PreCull : FsmEvent
    {
        void OnPreCull()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class BecameVisible : FsmEvent
    {
        void OnBecameVisible()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class BecameInvisible : FsmEvent
    {
        void OnBecameInvisible()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class PreRender : FsmEvent
    {
        void OnPreRender()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class RenderObject : FsmEvent
    {
        void OnRenderObject()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class RenderImage : FsmEvent
    {
        void OnRenderImage()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class PostRender : FsmEvent
    {
        void OnPostRender()
        {
            Notify();
        }
    }
}