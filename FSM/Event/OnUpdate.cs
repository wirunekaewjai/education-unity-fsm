using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class Updater : FsmObservable
    {
        void Update()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class LateUpdater : FsmObservable
    {
        void LateUpdate()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class FixedUpdater : FsmObservable
    {
        void FixedUpdate()
        {
            Notify();
        }
    }
}