using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class Reseter : FsmObservable
    {
        void Reset()
        {
            Notify();
        }
    }
}