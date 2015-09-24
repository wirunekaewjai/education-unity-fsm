using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class TriggerEnter : Observable<Collider>
    {
        void OnTriggerEnter(Collider other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public sealed class TriggerStay : Observable<Collider>
    {
        void OnTriggerStay(Collider other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public sealed class TriggerExit : Observable<Collider>
    {
        void OnTriggerExit(Collider other)
        {
            Notify(other);
        }
    }
}
