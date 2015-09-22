using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class TriggerEnter : FsmEvent<Collider>
    {
        void OnTriggerEnter(Collider other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class TriggerStay : FsmEvent<Collider>
    {
        void OnTriggerStay(Collider other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class TriggerExit : FsmEvent<Collider>
    {
        void OnTriggerExit(Collider other)
        {
            Notify(other);
        }
    }
}