using UnityEngine;

namespace Devdayo.FSM.Event
{
    [DisallowMultipleComponent]
    public sealed class AppResume : Observable
    {
        void OnApplicationPause(bool status)
        {
            if (false == status)
                Notify();
        }
    }

    [DisallowMultipleComponent]
    public sealed class AppPause : Observable
    {
        void OnApplicationPause(bool status)
        {
            if (true == status)
                Notify();
        }
    }
    
    [DisallowMultipleComponent]
    public class AppQuit : Observable
    {
        void OnApplicationQuit()
        {
            Notify();
        }
    }
}
