using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class BehaviourUpdate : Observable
    {
        void Update()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public sealed class BehaviourFixedUpdate : Observable
    {
        void FixedUpdate()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public sealed class BehaviourLateUpdate : Observable
    {
        void LateUpdate()
        {
            Notify();
        }
    }
}
