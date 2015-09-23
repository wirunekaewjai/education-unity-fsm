using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class Resumer : FsmObservable
    {
        void OnApplicationPause(bool status)
        {
            if (false == status)
                Notify();
        }
    }

    [DisallowMultipleComponent]
    public class Pauser : FsmObservable
    {
        void OnApplicationPause(bool status)
        {
            if (true == status)
                Notify();
        }
    }

}