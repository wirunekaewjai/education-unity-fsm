using UnityEngine;

namespace Devdayo
{
	public interface ICollisionEnter2D
	{
		void OnCollisionEnter2D(Collision2D other);
	}
	public interface ICollisionStay2D
	{
		void OnCollisionStay2D(Collision2D other);
	}
	public interface ICollisionExit2D
	{
		void OnCollisionExit2D(Collision2D other);
	}
}