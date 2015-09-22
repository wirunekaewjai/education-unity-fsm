using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class Reseter : FsmEvent
    {
        void Reset()
        {
            Notify();
        }
    }
}