using UnityEngine;
using UnityEngine.UI;

public class CoinUIController : MonoBehaviour 
{
	public Text coinText;

	void OnEnable()
	{
		CoinManager.Instance.Add(OnCoinChanged);
	}

	void OnDisable()
	{
		CoinManager.Instance.Remove(OnCoinChanged);
	}

	void OnCoinChanged(int coin)
	{
		coinText.text = coin.ToString();
	}
}
