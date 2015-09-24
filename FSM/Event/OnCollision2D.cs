using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class CollisionEnter2D : Observable<Collision2D>
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public sealed class CollisionStay2D : Observable<Collision2D>
    {
        void OnCollisionStay2D(Collision2D other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public sealed class CollisionExit2D : Observable<Collision2D>
    {
        void OnCollisionExit2D(Collision2D other)
        {
            Notify(other);
        }
    }
}
