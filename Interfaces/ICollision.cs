using UnityEngine;

namespace Devdayo
{
	public interface ICollisionEnter
	{
		void OnCollisionEnter(Collision other);
	}
	public interface ICollisionStay
	{
		void OnCollisionStay(Collision other);
	}
	public interface ICollisionExit
	{
		void OnCollisionExit(Collision other);
	}
}