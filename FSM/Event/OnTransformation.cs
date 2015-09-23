using UnityEngine;

namespace Devdayo
{
	[DisallowMultipleComponent]
	public class TransformChildrenChange : FsmObservable
	{
		void OnTransformChildrenChanged()
		{
			Notify();
		}
	}

	[DisallowMultipleComponent]
	public class TransformParentChange : FsmObservable
	{
		void OnTransformParentChanged()
		{
			Notify();
		}
	}
}