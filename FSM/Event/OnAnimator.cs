using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class AnimatorIK : Observable<int>
    {
        void OnAnimatorIK(int layerIndex)
        {
            Notify(layerIndex);
        }
    }

    [DisallowMultipleComponent]
    public sealed class AnimatorMove : Observable
    {
        void OnAnimatorMove()
        {
            Notify();
        }
    }
}
