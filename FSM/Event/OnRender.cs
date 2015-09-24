using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public class WillRenderObject : Observable
    {
        void OnWillRenderObject()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class PreCull : Observable
    {
        void OnPreCull()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class BecameVisible : Observable
    {
        void OnBecameVisible()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class BecameInvisible : Observable
    {
        void OnBecameInvisible()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class PreRender : Observable
    {
        void OnPreRender()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class RenderObject : Observable
    {
        void OnRenderObject()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class RenderImage : Observable<RenderTexture, RenderTexture>
    {
        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Notify(src, dest);
        }
    }

    [DisallowMultipleComponent]
    public class PostRender : Observable
    {
        void OnPostRender()
        {
            Notify();
        }
    }
}
