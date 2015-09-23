using UnityEngine;

// Ref : http://redframe-game.com/blog/global-managers-with-generic-singletons/
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    
    // Only-one instance in program. (singleton)
    private static T instance = null;
    public static T Instance
    {
        get
        {
            // Never created ?
            if(null == instance)
            {
                // Looking for instance.
                instance = FindObjectOfType<T>();
                
                // Found ?
                if(null == instance)
                {
                    // Just create our GameObject.
                    GameObject g = new GameObject();
                    g.hideFlags = HideFlags.HideAndDontSave;
                    
                    // Attach our FsmTask to GameObject.
                    instance = g.AddComponent<T>();
                }
            }
            
            // You Got It !!!
            return instance;
        }
    }
}