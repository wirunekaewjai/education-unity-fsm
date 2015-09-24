using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class InspectorReset : Observable
    {
        void Reset()
        {
            Notify();
        }
    }
}
