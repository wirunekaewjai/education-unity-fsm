using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class TriggerEnter2D : Observable<Collider2D>
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public sealed class TriggerStay2D : Observable<Collider2D>
    {
        void OnTriggerStay2D(Collider2D other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public sealed class TriggerExit2D : Observable<Collider2D>
    {
        void OnTriggerExit2D(Collider2D other)
        {
            Notify(other);
        }
    }
}
