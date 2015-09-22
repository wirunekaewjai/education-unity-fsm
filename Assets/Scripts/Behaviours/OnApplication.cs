using UnityEngine;

[DisallowMultipleComponent]
public class Resumer : FsmEvent
{
    void OnApplicationPause(bool status)
    {
        if (false == status)
            Notify();
    }
}

[DisallowMultipleComponent]
public class Pauser : FsmEvent
{
    void OnApplicationPause(bool status)
    {
        if(true == status)
            Notify();
    }
}
