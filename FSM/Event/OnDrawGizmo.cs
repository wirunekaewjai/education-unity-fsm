using UnityEngine;

namespace Devdayo
{
    [DisallowMultipleComponent]
    public class DrawGizmos : FsmObservable
    {
        void OnDrawGizmos()
        {
            Notify();
        }
    }

    [DisallowMultipleComponent]
    public class DrawGizmosSelected : FsmObservable
    {
        void OnDrawGizmosSelected()
        {
            Notify();
        }
    }
}
