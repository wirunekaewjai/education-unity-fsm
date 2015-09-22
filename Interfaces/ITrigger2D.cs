using UnityEngine;

namespace Devdayo
{
	public interface ITriggerEnter2D
	{
		void OnTriggerEnter2D(Collider2D other);
	}
	public interface ITriggerStay2D
	{
		void OnTriggerStay2D(Collider2D other);
	}
	public interface ITriggerExit2D
	{
		void OnTriggerExit2D(Collider2D other);
	}
}