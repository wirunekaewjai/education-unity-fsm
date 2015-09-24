using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class DrawGizmos : Observable
    {
        void OnDrawGizmos()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public sealed class DrawGizmosSelected : Observable
    {
        void OnDrawGizmosSelected()
        {
            Notify();
        }
    }
}
