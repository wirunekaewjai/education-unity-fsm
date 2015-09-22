using UnityEngine;

[DisallowMultipleComponent]
public class Reseter : FsmEvent
{
    void Reset()
    {
        Notify();
    }
}
