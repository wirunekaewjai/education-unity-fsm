using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class TransformParentChange : Observable
    {
        void OnTransformParentChanged()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public sealed class TransformChildrenChange : Observable
    {
        void OnTransformChildrenChanged()
        {
            Notify();
        }
    }
}
