using UnityEngine;
using System;

public class Tween : MonoBehaviour
{
	private Rigidbody2D _rigidbody;
	private Action _state;
	private int _index;
	private float _timeCount;
	
	public bool autoPlay = true;
	public bool useRigidbody = false;

	public float moveSpeed = 3;
	public float delay = 2;

	public Vector3[] points;

	public Action onArriveToNext;

	void Awake()
	{
		// Not Required.
		_rigidbody = GetComponent<Rigidbody2D> ();
		_state = OnStop;
		_index = -1;
		_timeCount = 0;
	}

	void Update ()
	{
		if(null != _state)
            _state();
    }

	void OnMove()
	{
		// Read Position
		Vector3 current = transform.position;
		Vector3 target = points [_index];
		
		Vector3 direction = (target - current).normalized;
		float distance = Vector3.Distance(target, current);
		
		Vector3 velocity = direction * moveSpeed;


		if (null != _rigidbody && useRigidbody)
		{
			// Velocity will not effect to Children
			_rigidbody.velocity = velocity;
		}
		else
		{
			transform.Translate(velocity * Time.deltaTime);
		}
		
		if(distance <= 0.1f)
		{
			transform.position = target;

			if (null != _rigidbody && useRigidbody)
				_rigidbody.Sleep();

			_state = OnStop;

			if(null != onArriveToNext)
				onArriveToNext();
		}

	}

	void OnStop()
	{
		_timeCount += Time.deltaTime;
		if(_timeCount >= delay && autoPlay)
		{
			_timeCount = 0;
			_index += 1;
			
			// Circular Array e.g., "0 1 2 3 0 1 2 3"
			if (_index >= points.Length)
				_index = 0;
			
			_state = OnMove;
		}
	}

	public void MoveTo(int i)
	{
		_index = i;

		// Circular Array e.g., "0 1 2 3 0 1 2 3"
		if (_index >= points.Length)
			_index = 0;
		
		_state = OnMove;
	}

	public int currentIndex
	{
		get
		{
			return _index;
		}
	}
}
