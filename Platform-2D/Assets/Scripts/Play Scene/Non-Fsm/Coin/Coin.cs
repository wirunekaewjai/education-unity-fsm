using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D c)
	{
		if (!c.CompareTag ("Player"))
			return;

		CoinManager.Instance.Increase();
		DestroyObject (gameObject);
	}
}
