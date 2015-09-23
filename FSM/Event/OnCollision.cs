using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class CollisionEnter : FsmObservable<Collision>
    {
        void OnCollisionEnter(Collision other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class CollisionStay : FsmObservable<Collision>
    {
        void OnCollisionStay(Collision other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class CollisionExit : FsmObservable<Collision>
    {
        void OnCollisionExit(Collision other)
        {
            Notify(other);
        }
    }
}