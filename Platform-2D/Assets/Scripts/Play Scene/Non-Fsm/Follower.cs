using UnityEngine;

public class Follower : MonoBehaviour 
{
	public Transform target;
	public float moveSpeed = 3;
	public float maxDistance = 10;

	private Vector3 offset;

	void OnEnable () 
	{
		float z = transform.position.z;
		offset = new Vector3(0, 0, z);

		transform.position = target.position + offset;
	}

	void Update ()
	{
		Vector2 currentPosition = transform.position;
		Vector2 targetPosition = target.position;

		Vector2 direction = (targetPosition - currentPosition).normalized;
		float distance = Vector2.Distance(targetPosition, currentPosition);

		if(distance < maxDistance)
		{
			Vector2 v = direction * distance * moveSpeed * Time.deltaTime;
			transform.Translate(v.x, v.y, 0);
		}
		else
		{
			transform.position = target.position + offset;
		}


		//Vector3 lerp = Vector3.Lerp (currentPosition, targetPosition, 0.1f);
		//transform.position = lerp + offset;
	}
}
