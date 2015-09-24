using UnityEngine;

public class CoinManager : MonoBehaviour 
{ 
	// Start Singleton Section
	private static CoinManager instance = null;
	public static CoinManager Instance
	{
		get
		{
			if(null == instance)
			{
				instance = FindObjectOfType<CoinManager>();
				if(null == instance)
				{
					GameObject g = new GameObject();
                    g.hideFlags = HideFlags.HideAndDontSave;
					g.name = "Coin Manager (Singleton)";

					instance = g.AddComponent<CoinManager>();
				}
			}

			return instance;
		}
	}


	void OnDestroy()
	{
		instance = null;
	}
	// End Singleton Section

	// Start Instance Section
    private void OnEnable()
    {
        StartCoroutine(OnLoad());
    }

    private System.Collections.IEnumerator OnLoad()
    {
        yield return new WaitForSeconds(1f);

        coin = PlayerPrefs.GetInt("Coin", 0);

        NotifyChanged();
    }

	public delegate void Callback(int coin);

	private Callback callbacks;
	public int coin { get; private set; }

	public void Add(Callback callback)
	{
		callbacks += callback;
	}

	public void Remove(Callback callback)
	{
		callbacks -= callback;
	}

	public void Increase()
	{
		coin += 1;
		NotifyChanged();
	}

	public void Decrease()
	{
		coin -= 1;
		NotifyChanged();
	}

	private void NotifyChanged()
	{
		if(null != callbacks)
		{
			callbacks(coin);
		}
	}


}
