using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour 
{
	public static void Restart()
	{
		int level = Application.loadedLevel;
		Application.LoadLevel (level);
	}

	void OnTriggerExit2D(Collider2D c)
	{
		Restart ();
	}
}
