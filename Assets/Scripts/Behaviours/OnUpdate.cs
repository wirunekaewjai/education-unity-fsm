using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class Updater : FsmEvent
    {
        void Update()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class LateUpdater : FsmEvent
    {
        void LateUpdate()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class FixedUpdater : FsmEvent
    {
        void Update()
        {
            Notify();
        }
    }
}