using UnityEngine;

[DisallowMultipleComponent]
public class CollisionEnter2D : FsmEvent<Collision2D>
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Notify(other);
    }
}

[DisallowMultipleComponent]
public class CollisionStay2D : FsmEvent<Collision2D>
{
    void OnCollisionStay2D(Collision2D other)
    {
        Notify(other);
    }
}

[DisallowMultipleComponent]
public class CollisionExit2D : FsmEvent<Collision2D>
{
    void OnCollisionExit2D(Collision2D other)
    {
        Notify(other);
    }
}