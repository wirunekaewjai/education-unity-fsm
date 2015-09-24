using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D c)
	{
		if (!c.gameObject.CompareTag ("Player"))
			return;

		c.transform.SetParent (transform);
	}

	void OnCollisionExit2D(Collision2D c)
	{
		if (!c.gameObject.CompareTag ("Player"))
			return;
		
		c.transform.SetParent (null);
	}
}
