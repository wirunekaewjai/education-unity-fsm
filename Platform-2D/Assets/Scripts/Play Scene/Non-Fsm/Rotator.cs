using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
	public float speed = 1;

	void Update()
	{
		transform.Rotate (0, speed, 0);
	}
}
