using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class DrawGizmos : FsmEvent
    {
        void OnDrawGizmos()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class DrawGizmosSelected : FsmEvent
    {
        void OnDrawGizmosSelected()
        {
            Notify();
        }
    }
}
