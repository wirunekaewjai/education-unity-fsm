using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class CollisionEnter : Observable<Collision>
    {
        void OnCollisionEnter(Collision other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public sealed class CollisionStay : Observable<Collision>
    {
        void OnCollisionStay(Collision other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public sealed class CollisionExit : Observable<Collision>
    {
        void OnCollisionExit(Collision other)
        {
            Notify(other);
        }
    }
}
