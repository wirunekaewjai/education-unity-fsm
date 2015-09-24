// Contain "MonoBehaviour" Class
using UnityEngine;

namespace Devdayo.FSM.Core
{
    // <T> is your custom monobehaviour class name.
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Only-one instance in program per class type. (singleton)
        private static T instance = null;
        public static T Instance
        {
            get
            {
                // Never created ?
                if (null == instance)
                {
                    // Looking for instance.
                    instance = FindObjectOfType<T>();

                    // Found ?
                    if (null == instance)
                    {
                        // Just create our GameObject.
                        GameObject g = new GameObject();
                        g.name = "Singleton Object";
                        g.hideFlags = HideFlags.HideInHierarchy;
                        // g.hideFlags = HideFlags.HideAndDontSave;

                        // Attach our FsmTask to GameObject.
                        instance = g.AddComponent<T>();
                    }
                }

                // You Got It !!!
                return instance;
            }
        }

    }
}
