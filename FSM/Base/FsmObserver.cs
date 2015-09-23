// Contain "GameObject" Class
using UnityEngine;

// Contain "Action" Class
using System;

namespace Devdayo
{
	public abstract class FsmObserver
	{
		public void Subscribe()
		{
			OnSubscribe();
		}
		
		public void Unsubscribe()
		{
			OnUnsubscribe();
		}

		// Subscribe helper
		protected void Subscribe<T>(GameObject observable, Action a) where T : FsmObservable
		{
			FsmObservable.Subscribe<T>(observable, a);
		}
		protected void Subscribe<T, A>(GameObject observable, Action<A> a) where T : FsmObservable<A>
		{
			FsmObservable<A>.Subscribe<T>(observable, a);
		}
		protected void Subscribe<T, A, B>(GameObject observable, Action<A, B> a) where T : FsmObservable<A, B>
		{
			FsmObservable<A, B>.Subscribe<T>(observable, a);
		}
		
		// Unsubscribe helper
		protected void Unsubscribe<T>(GameObject observable, Action a) where T : FsmObservable
		{
			FsmObservable.Unsubscribe<T>(observable, a);
		}
		protected void Unsubscribe<T, A>(GameObject observable, Action<A> a) where T : FsmObservable<A>
		{
			FsmObservable<A>.Unsubscribe<T>(observable, a);
		}
		protected void Unsubscribe<T, A, B>(GameObject observable, Action<A, B> a) where T : FsmObservable<A, B>
		{
			FsmObservable<A, B>.Unsubscribe<T>(observable, a);
		}

		// Subscription Methods
		// Using for Subscribe/Unsubscribe Update, Collision or Trigger Events
		protected virtual void OnSubscribe() { }
		protected virtual void OnUnsubscribe() { }
	}
}