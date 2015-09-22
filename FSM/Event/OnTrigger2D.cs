using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class TriggerEnter2D : FsmEvent<Collider2D>
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class TriggerStay2D : FsmEvent<Collider2D>
    {
        void OnTriggerStay2D(Collider2D other)
        {
            Notify(other);
        }
    }

    [DisallowMultipleComponent]
    public class TriggerExit2D : FsmEvent<Collider2D>
    {
        void OnTriggerExit2D(Collider2D other)
        {
            Notify(other);
        }
    }
}