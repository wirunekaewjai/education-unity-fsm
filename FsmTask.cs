using UnityEngine;
using System.Collections.Generic;
using System;

namespace Devdayo
{
	
	public class FsmTask : MonoBehaviour 
	{
		// Singleton
		private static FsmTask instance = null;
		public static FsmTask Instance
		{
			get
			{
				if(null == instance)
				{
					instance = FindObjectOfType<FsmTask>();
					
					if(null == instance)
					{
						GameObject g = new GameObject();
						g.hideFlags = HideFlags.HideAndDontSave;
						
						instance = g.AddComponent<FsmTask>();
					}
				}
				
				return instance;
			}
		}
		
		private void OnDestroy()
		{
			instance = null;
		}
		
		// Instance
		private readonly Queue<Fsm> queues = new Queue<Fsm>();
		
		public void Enqueue(Fsm fsm)
		{
			queues.Enqueue(fsm);
		}

		private void Start()
		{
			StartCoroutine(OnUpdate());
		}
		
		private System.Collections.IEnumerator OnUpdate()
		{
			while(true)
			{
				for (int i = 0; i < 200 && queues.Count > 0; i++) 
				{	
					Fsm fsm = queues.Dequeue();
					fsm.ApplyNextState();
				}
				yield return new WaitForEndOfFrame();
			}
		}
		
	}
}
