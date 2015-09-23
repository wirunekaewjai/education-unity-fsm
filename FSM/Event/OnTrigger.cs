using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class TriggerEnter : FsmObservable<Collider>
    {
        void OnTriggerEnter(Collider other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class TriggerStay : FsmObservable<Collider>
    {
        void OnTriggerStay(Collider other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class TriggerExit : FsmObservable<Collider>
    {
        void OnTriggerExit(Collider other)
        {
            Notify(other);
        }
    }
}