using UnityEngine;

[DisallowMultipleComponent]
public class TriggerEnter2D : FsmEvent<Collider2D>
{
    void OnTrigger2DEnter(Collider2D other)
    {
        Notify(other);
    }
}

[DisallowMultipleComponent]
public class TriggerStay2D : FsmEvent<Collider2D>
{
    void OnTrigger2DStay(Collider2D other)
    {
        Notify(other);
    }
}

[DisallowMultipleComponent]
public class TriggerExit2D : FsmEvent<Collider2D>
{
    void OnTrigger2DExit(Collider2D other)
    {
        Notify(other);
    }
}