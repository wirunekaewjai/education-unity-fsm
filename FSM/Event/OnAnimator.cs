using UnityEngine;

namespace Devdayo
{
	[DisallowMultipleComponent]
	public class AnimatorIK : FsmObservable<int>
	{
		void OnAnimatorIK(int layerIndex)
		{
			Notify(layerIndex);
		}
	}
	
	[DisallowMultipleComponent]
	public class AnimatorMove : FsmObservable
	{
		void OnAnimatorMove()
		{
			Notify();
		}
	}
}