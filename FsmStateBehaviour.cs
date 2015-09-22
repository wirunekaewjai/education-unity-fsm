// Contain "GameObject" Class
using UnityEngine;

// Contain "Activator", "Enum", "Type" Class
using System;

// Contain "MethodInfo" Class
using System.Reflection;

// Contain "List<T>" Class
using System.Collections.Generic;

namespace Devdayo
{
    // Middle-weight Fsm State.
    // Please derived this class if you want to create state like Mono Behaviour.
    public abstract class FsmStateBehaviour : FsmState
    {
        // Override from FsmState.cs
        public override void OnSubscribe()
        {
            // Call FsmState.OnSubscribe
            base.OnSubscribe();

			// Get self instance.
			object instance = this;
			
			// Get self type.
			Type type = GetType();

            // On Reset
			if (instance is IReset)
                FsmEvent.Subscribe<Reseter>(GetObservable(type), ((IReset)this).OnReset);

            // On Application
            if (instance is IResume)
				FsmEvent.Subscribe<Resumer>(GetObservable(type), ((IResume)this).OnResume);
			if (instance is IPause)
				FsmEvent.Subscribe<Pauser>(GetObservable(type), ((IPause)this).OnPause);

            // On Update
            if (instance is IUpdate)
				FsmEvent.Subscribe<Updater>(GetObservable(type), ((IUpdate)this).OnUpdate);
			if (instance is IFixedUpdate)
				FsmEvent.Subscribe<FixedUpdater>(GetObservable(type), ((IFixedUpdate)this).OnFixedUpdate);
			if (instance is ILateUpdate)
				FsmEvent.Subscribe<LateUpdater>(GetObservable(type), ((ILateUpdate)this).OnLateUpdate);

            // On Draw
			if (instance is IDrawGizmos)
				FsmEvent.Subscribe<DrawGizmos>(GetObservable(type), ((IDrawGizmos)this).OnDrawGizmos);
			if (instance is IDrawGizmosSelected)
				FsmEvent.Subscribe<DrawGizmosSelected>(GetObservable(type), ((IDrawGizmosSelected)this).OnDrawGizmosSelected);

            // On Collision
            if (instance is ICollisionEnter)
				FsmEvent<Collision>.Subscribe<CollisionEnter>(GetObservable(type), ((ICollisionEnter)this).OnCollisionEnter);
			if (instance is ICollisionStay)
				FsmEvent<Collision>.Subscribe<CollisionStay>(GetObservable(type), ((ICollisionStay)this).OnCollisionStay);
			if (instance is ICollisionExit)
				FsmEvent<Collision>.Subscribe<CollisionExit>(GetObservable(type), ((ICollisionExit)this).OnCollisionExit);

            // On Collision 2D
            if (instance is ICollisionEnter2D)
				FsmEvent<Collision2D>.Subscribe<CollisionEnter2D>(GetObservable(type), ((ICollisionEnter2D)this).OnCollisionEnter2D);
			if (instance is ICollisionStay2D)
				FsmEvent<Collision2D>.Subscribe<CollisionStay2D>(GetObservable(type), ((ICollisionStay2D)this).OnCollisionStay2D);
			if (instance is ICollisionExit2D)
				FsmEvent<Collision2D>.Subscribe<CollisionExit2D>(GetObservable(type), ((ICollisionExit2D)this).OnCollisionExit2D);

            // On Trigger
            if (instance is ITriggerEnter)
				FsmEvent<Collider>.Subscribe<TriggerEnter>(GetObservable(type), ((ITriggerEnter)this).OnTriggerEnter);
			if (instance is ITriggerStay)
				FsmEvent<Collider>.Subscribe<TriggerStay>(GetObservable(type), ((ITriggerStay)this).OnTriggerStay);
			if (instance is ITriggerExit)
				FsmEvent<Collider>.Subscribe<TriggerExit>(GetObservable(type), ((ITriggerExit)this).OnTriggerExit);

            // On Trigger 2D
			if (instance is ITriggerEnter2D)
				FsmEvent<Collider2D>.Subscribe<TriggerEnter2D>(GetObservable(type), ((ITriggerEnter2D)this).OnTriggerEnter2D);
			if (instance is ITriggerStay2D)
				FsmEvent<Collider2D>.Subscribe<TriggerStay2D>(GetObservable(type), ((ITriggerStay2D)this).OnTriggerStay2D);
			if (instance is ITriggerExit2D)
				FsmEvent<Collider2D>.Subscribe<TriggerExit2D>(GetObservable(type), ((ITriggerExit2D)this).OnTriggerExit2D);

            // On Render
			if (instance is IWillRenderObject)
				FsmEvent.Subscribe<WillRenderObject>(GetObservable(type), ((IWillRenderObject)this).OnWillRenderObject);
			if (instance is IPreCull)
				FsmEvent.Subscribe<PreCull>(GetObservable(type), ((IPreCull)this).OnPreCull);
			if (instance is IBecameVisible)
				FsmEvent.Subscribe<BecameVisible>(GetObservable(type), ((IBecameVisible)this).OnBecameVisible);
			if (instance is IBecameInvisible)
				FsmEvent.Subscribe<BecameInvisible>(GetObservable(type), ((IBecameInvisible)this).OnBecameInvisible);
			if (instance is IPreRender)
				FsmEvent.Subscribe<PreRender>(GetObservable(type), ((IPreRender)this).OnPreRender);
			if (instance is IRenderObject)
				FsmEvent.Subscribe<RenderObject>(GetObservable(type), ((IRenderObject)this).OnRenderObject);
			if (instance is IRenderImage)
				FsmEvent.Subscribe<RenderImage>(GetObservable(type), ((IRenderImage)this).OnRenderImage);
			if (instance is IPostRender)
				FsmEvent.Subscribe<PostRender>(GetObservable(type), ((IPostRender)this).OnPostRender);
        }

        // Override from FsmState.cs
        public override void OnUnsubscribe()
        {
            // Call FsmState.OnSubscribe
            base.OnUnsubscribe();

			// Get self instance.
			object instance = this;

			// Get self type.
			Type type = GetType();
			
			// On Reset
			if (instance is IReset)
				FsmEvent.Unsubscribe<Reseter>(GetObservable(type), ((IReset)this).OnReset);
			
			// On Application
			if (instance is IResume)
				FsmEvent.Unsubscribe<Resumer>(GetObservable(type), ((IResume)this).OnResume);
			if (instance is IPause)
				FsmEvent.Unsubscribe<Pauser>(GetObservable(type), ((IPause)this).OnPause);
			
			// On Update
			if (instance is IUpdate)
				FsmEvent.Unsubscribe<Updater>(GetObservable(type), ((IUpdate)this).OnUpdate);
			if (instance is IFixedUpdate)
				FsmEvent.Unsubscribe<FixedUpdater>(GetObservable(type), ((IFixedUpdate)this).OnFixedUpdate);
			if (instance is ILateUpdate)
				FsmEvent.Unsubscribe<LateUpdater>(GetObservable(type), ((ILateUpdate)this).OnLateUpdate);
			
			// On Draw
			if (instance is IDrawGizmos)
				FsmEvent.Unsubscribe<DrawGizmos>(GetObservable(type), ((IDrawGizmos)this).OnDrawGizmos);
			if (instance is IDrawGizmosSelected)
				FsmEvent.Unsubscribe<DrawGizmosSelected>(GetObservable(type), ((IDrawGizmosSelected)this).OnDrawGizmosSelected);
			
			// On Collision
			if (instance is ICollisionEnter)
				FsmEvent<Collision>.Unsubscribe<CollisionEnter>(GetObservable(type), ((ICollisionEnter)this).OnCollisionEnter);
			if (instance is ICollisionStay)
				FsmEvent<Collision>.Unsubscribe<CollisionStay>(GetObservable(type), ((ICollisionStay)this).OnCollisionStay);
			if (instance is ICollisionExit)
				FsmEvent<Collision>.Unsubscribe<CollisionExit>(GetObservable(type), ((ICollisionExit)this).OnCollisionExit);
			
			// On Collision 2D
			if (instance is ICollisionEnter2D)
				FsmEvent<Collision2D>.Unsubscribe<CollisionEnter2D>(GetObservable(type), ((ICollisionEnter2D)this).OnCollisionEnter2D);
			if (instance is ICollisionStay2D)
				FsmEvent<Collision2D>.Unsubscribe<CollisionStay2D>(GetObservable(type), ((ICollisionStay2D)this).OnCollisionStay2D);
			if (instance is ICollisionExit2D)
				FsmEvent<Collision2D>.Unsubscribe<CollisionExit2D>(GetObservable(type), ((ICollisionExit2D)this).OnCollisionExit2D);
			
			// On Trigger
			if (instance is ITriggerEnter)
				FsmEvent<Collider>.Unsubscribe<TriggerEnter>(GetObservable(type), ((ITriggerEnter)this).OnTriggerEnter);
			if (instance is ITriggerStay)
				FsmEvent<Collider>.Unsubscribe<TriggerStay>(GetObservable(type), ((ITriggerStay)this).OnTriggerStay);
			if (instance is ITriggerExit)
				FsmEvent<Collider>.Unsubscribe<TriggerExit>(GetObservable(type), ((ITriggerExit)this).OnTriggerExit);
			
			// On Trigger 2D
			if (instance is ITriggerEnter2D)
				FsmEvent<Collider2D>.Unsubscribe<TriggerEnter2D>(GetObservable(type), ((ITriggerEnter2D)this).OnTriggerEnter2D);
			if (instance is ITriggerStay2D)
				FsmEvent<Collider2D>.Unsubscribe<TriggerStay2D>(GetObservable(type), ((ITriggerStay2D)this).OnTriggerStay2D);
			if (instance is ITriggerExit2D)
				FsmEvent<Collider2D>.Unsubscribe<TriggerExit2D>(GetObservable(type), ((ITriggerExit2D)this).OnTriggerExit2D);
			
			// On Render
			if (instance is IWillRenderObject)
				FsmEvent.Unsubscribe<WillRenderObject>(GetObservable(type), ((IWillRenderObject)this).OnWillRenderObject);
			if (instance is IPreCull)
				FsmEvent.Unsubscribe<PreCull>(GetObservable(type), ((IPreCull)this).OnPreCull);
			if (instance is IBecameVisible)
				FsmEvent.Unsubscribe<BecameVisible>(GetObservable(type), ((IBecameVisible)this).OnBecameVisible);
			if (instance is IBecameInvisible)
				FsmEvent.Unsubscribe<BecameInvisible>(GetObservable(type), ((IBecameInvisible)this).OnBecameInvisible);
			if (instance is IPreRender)
				FsmEvent.Unsubscribe<PreRender>(GetObservable(type), ((IPreRender)this).OnPreRender);
			if (instance is IRenderObject)
				FsmEvent.Unsubscribe<RenderObject>(GetObservable(type), ((IRenderObject)this).OnRenderObject);
			if (instance is IRenderImage)
				FsmEvent.Unsubscribe<RenderImage>(GetObservable(type), ((IRenderImage)this).OnRenderImage);
			if (instance is IPostRender)
				FsmEvent.Unsubscribe<PostRender>(GetObservable(type), ((IPostRender)this).OnPostRender);
        }

        // Virtual Sections.
        // Override when you want to insert your own condition.
        // e.g., if CollisionEnter then return child gameobject.
        protected virtual GameObject GetObservable(Type type)
        {
            // Unconditional.
            return gameObject;
        }
    }
}