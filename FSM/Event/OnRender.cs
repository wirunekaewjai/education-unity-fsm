using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class WillRenderObject : FsmObservable
    {
        void OnWillRenderObject()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class PreCull : FsmObservable
    {
        void OnPreCull()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class BecameVisible : FsmObservable
    {
        void OnBecameVisible()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class BecameInvisible : FsmObservable
    {
        void OnBecameInvisible()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class PreRender : FsmObservable
    {
        void OnPreRender()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class RenderObject : FsmObservable
    {
        void OnRenderObject()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class RenderImage : FsmObservable<RenderTexture, RenderTexture>
    {
        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Notify(src, dest);
        }
    }

    [DisallowMultipleComponent]
    public class PostRender : FsmObservable
    {
        void OnPostRender()
        {
            Notify();
        }
    }
}