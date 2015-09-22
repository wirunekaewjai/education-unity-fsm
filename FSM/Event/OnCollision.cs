using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class CollisionEnter : FsmEvent<Collision>
    {
        void OnCollisionEnter(Collision other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class CollisionStay : FsmEvent<Collision>
    {
        void OnCollisionStay(Collision other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class CollisionExit : FsmEvent<Collision>
    {
        void OnCollisionExit(Collision other)
        {
            Notify(other);
        }
    }
}