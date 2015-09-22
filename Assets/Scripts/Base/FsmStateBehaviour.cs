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
        // Define Events
        public enum Event
        {
            OnReset,
            OnResume,
            OnPause,

            OnUpdate,
            OnFixedUpdate,
            OnLateUpdate,

            OnDrawGizmos,
            OnDrawGizmosSelected,

            OnCollisionEnter,
            OnCollisionStay,
            OnCollisionExit,
            OnCollisionEnter2D,
            OnCollisionStay2D,
            OnCollisionExit2D,

            OnTriggerEnter,
            OnTriggerStay,
            OnTriggerExit,
            OnTriggerEnter2D,
            OnTriggerStay2D,
            OnTriggerExit2D,

            OnWillRenderObject,
            OnPreCull,
            OnBecameVisible,
            OnBecameInvisible,
            OnPreRender,
            OnRenderObject,
            OnRenderImage,
            OnPostRender
        }

        // Keep available events from reflection.
        private readonly List<Event> events = new List<Event>();

        // Override to custom logic while instance creating.
        protected override void OnCreate(Fsm fsm)
        {
            // Call super-class OnCreate.
            base.OnCreate(fsm);

            // Get Type from this class
            Type type = GetType();

            // Get Public Methods from Type
            MethodInfo[] infos = type.GetMethods();

            // Loop every methods to detect an event.
            foreach (MethodInfo info in infos)
            {
                // true : when founded a method in this class.
                if (info.DeclaringType == type)
                {
                    DetectSubscribeEvent(info);
                }
            }
        }

        // Find Observable Event.
        private void DetectSubscribeEvent(MethodInfo info)
        {
            // Read Type of Event
            Type type = typeof(Event);

            // false : when info.Name != Value Of Event
            // e.g., if (info.Name = "Awake") then false
            // e.g., if (info.Name = "Update") then true
            if (!Enum.IsDefined(type, info.Name))
                return;

            // Parse info.Name to event
            Event e = (Event)Enum.Parse(type, info.Name);

            // remember subscribe event.
            events.Add(e);
        }

        // Override from FsmState.cs
        public override void OnSubscribe()
        {
            // Call FsmState.OnSubscribe
            base.OnSubscribe();

            GameObject g = gameObject;

            // On Reset
            if (events.Contains(Event.OnReset))
                FsmEvent.Subscribe<Reseter>(GetOwner(Event.OnReset), OnReset);

            // On Application
            if (events.Contains(Event.OnResume))
                FsmEvent.Subscribe<Resumer>(GetOwner(Event.OnResume), OnResume);
            if (events.Contains(Event.OnPause))
                FsmEvent.Subscribe<Pauser>(GetOwner(Event.OnPause), OnPause);

            // On Update
            if (events.Contains(Event.OnUpdate))
                FsmEvent.Subscribe<Updater>(GetOwner(Event.OnUpdate), OnUpdate);
            if (events.Contains(Event.OnFixedUpdate))
                FsmEvent.Subscribe<FixedUpdater>(GetOwner(Event.OnFixedUpdate), OnFixedUpdate);
            if (events.Contains(Event.OnLateUpdate))
                FsmEvent.Subscribe<LateUpdater>(GetOwner(Event.OnLateUpdate), OnLateUpdate);

            // On Draw
            if (events.Contains(Event.OnDrawGizmos))
                FsmEvent.Subscribe<DrawGizmos>(GetOwner(Event.OnDrawGizmos), OnDrawGizmos);
            if (events.Contains(Event.OnDrawGizmosSelected))
                FsmEvent.Subscribe<DrawGizmosSelected>(GetOwner(Event.OnDrawGizmos), OnDrawGizmosSelected);

            // On Collision
            if (events.Contains(Event.OnCollisionEnter))
                FsmEvent<Collision>.Subscribe<CollisionEnter>(GetOwner(Event.OnCollisionEnter), OnCollisionEnter);
            if (events.Contains(Event.OnCollisionStay))
                FsmEvent<Collision>.Subscribe<CollisionStay>(GetOwner(Event.OnCollisionStay), OnCollisionStay);
            if (events.Contains(Event.OnCollisionExit))
                FsmEvent<Collision>.Subscribe<CollisionExit>(GetOwner(Event.OnCollisionExit), OnCollisionExit);

            // On Collision 2D
            if (events.Contains(Event.OnCollisionEnter2D))
                FsmEvent<Collision2D>.Subscribe<CollisionEnter2D>(GetOwner(Event.OnCollisionEnter2D), OnCollisionEnter2D);
            if (events.Contains(Event.OnCollisionStay2D))
                FsmEvent<Collision2D>.Subscribe<CollisionStay2D>(GetOwner(Event.OnCollisionStay2D), OnCollisionStay2D);
            if (events.Contains(Event.OnCollisionExit2D))
                FsmEvent<Collision2D>.Subscribe<CollisionExit2D>(GetOwner(Event.OnCollisionExit2D), OnCollisionExit2D);

            // On Trigger
            if (events.Contains(Event.OnTriggerEnter))
                FsmEvent<Collider>.Subscribe<TriggerEnter>(GetOwner(Event.OnTriggerEnter), OnTriggerEnter);
            if (events.Contains(Event.OnTriggerStay))
                FsmEvent<Collider>.Subscribe<TriggerStay>(GetOwner(Event.OnTriggerStay), OnTriggerStay);
            if (events.Contains(Event.OnTriggerExit))
                FsmEvent<Collider>.Subscribe<TriggerExit>(GetOwner(Event.OnTriggerExit), OnTriggerExit);

            // On Trigger 2D
            if (events.Contains(Event.OnTriggerEnter2D))
                FsmEvent<Collider2D>.Subscribe<TriggerEnter2D>(GetOwner(Event.OnTriggerEnter2D), OnTriggerEnter2D);
            if (events.Contains(Event.OnTriggerStay2D))
                FsmEvent<Collider2D>.Subscribe<TriggerStay2D>(GetOwner(Event.OnTriggerStay2D), OnTriggerStay2D);
            if (events.Contains(Event.OnTriggerExit2D))
                FsmEvent<Collider2D>.Subscribe<TriggerExit2D>(GetOwner(Event.OnTriggerExit2D), OnTriggerExit2D);

            // On Render
            if (events.Contains(Event.OnWillRenderObject))
                FsmEvent.Subscribe<WillRenderObject>(GetOwner(Event.OnWillRenderObject), OnWillRenderObject);
            if (events.Contains(Event.OnPreCull))
                FsmEvent.Subscribe<PreCull>(GetOwner(Event.OnPreCull), OnPreCull);
            if (events.Contains(Event.OnBecameVisible))
                FsmEvent.Subscribe<BecameVisible>(GetOwner(Event.OnBecameVisible), OnBecameVisible);
            if (events.Contains(Event.OnBecameInvisible))
                FsmEvent.Subscribe<BecameInvisible>(GetOwner(Event.OnBecameInvisible), OnBecameInvisible);
            if (events.Contains(Event.OnPreRender))
                FsmEvent.Subscribe<PreRender>(GetOwner(Event.OnPreRender), OnPreRender);
            if (events.Contains(Event.OnRenderObject))
                FsmEvent.Subscribe<RenderObject>(GetOwner(Event.OnRenderObject), OnRenderObject);
            if (events.Contains(Event.OnRenderImage))
                FsmEvent.Subscribe<RenderImage>(GetOwner(Event.OnRenderImage), OnRenderImage);
            if (events.Contains(Event.OnPostRender))
                FsmEvent.Subscribe<PostRender>(GetOwner(Event.OnPostRender), OnPostRender);
        }

        // Override from FsmState.cs
        public override void OnUnsubscribe()
        {
            // Call FsmState.OnSubscribe
            base.OnUnsubscribe();

            // On Reset
            if (events.Contains(Event.OnReset))
                FsmEvent.Unsubscribe<Reseter>(GetOwner(Event.OnReset), OnReset);

            // On Application
            if (events.Contains(Event.OnResume))
                FsmEvent.Unsubscribe<Resumer>(GetOwner(Event.OnResume), OnResume);
            if (events.Contains(Event.OnPause))
                FsmEvent.Unsubscribe<Pauser>(GetOwner(Event.OnPause), OnPause);

            // On Update
            if (events.Contains(Event.OnUpdate))
                FsmEvent.Unsubscribe<Updater>(GetOwner(Event.OnUpdate), OnUpdate);
            if (events.Contains(Event.OnFixedUpdate))
                FsmEvent.Unsubscribe<FixedUpdater>(GetOwner(Event.OnFixedUpdate), OnFixedUpdate);
            if (events.Contains(Event.OnLateUpdate))
                FsmEvent.Unsubscribe<LateUpdater>(GetOwner(Event.OnLateUpdate), OnLateUpdate);

            // On Draw
            if (events.Contains(Event.OnDrawGizmos))
                FsmEvent.Unsubscribe<DrawGizmos>(GetOwner(Event.OnDrawGizmos), OnDrawGizmos);
            if (events.Contains(Event.OnDrawGizmosSelected))
                FsmEvent.Unsubscribe<DrawGizmosSelected>(GetOwner(Event.OnDrawGizmos), OnDrawGizmosSelected);

            // On Collision
            if (events.Contains(Event.OnCollisionEnter))
                FsmEvent<Collision>.Unsubscribe<CollisionEnter>(GetOwner(Event.OnCollisionEnter), OnCollisionEnter);
            if (events.Contains(Event.OnCollisionStay))
                FsmEvent<Collision>.Unsubscribe<CollisionStay>(GetOwner(Event.OnCollisionStay), OnCollisionStay);
            if (events.Contains(Event.OnCollisionExit))
                FsmEvent<Collision>.Unsubscribe<CollisionExit>(GetOwner(Event.OnCollisionExit), OnCollisionExit);

            // On Collision 2D
            if (events.Contains(Event.OnCollisionEnter2D))
                FsmEvent<Collision2D>.Unsubscribe<CollisionEnter2D>(GetOwner(Event.OnCollisionEnter2D), OnCollisionEnter2D);
            if (events.Contains(Event.OnCollisionStay2D))
                FsmEvent<Collision2D>.Unsubscribe<CollisionStay2D>(GetOwner(Event.OnCollisionStay2D), OnCollisionStay2D);
            if (events.Contains(Event.OnCollisionExit2D))
                FsmEvent<Collision2D>.Unsubscribe<CollisionExit2D>(GetOwner(Event.OnCollisionExit2D), OnCollisionExit2D);

            // On Trigger
            if (events.Contains(Event.OnTriggerEnter))
                FsmEvent<Collider>.Unsubscribe<TriggerEnter>(GetOwner(Event.OnTriggerEnter), OnTriggerEnter);
            if (events.Contains(Event.OnTriggerStay))
                FsmEvent<Collider>.Unsubscribe<TriggerEnter>(GetOwner(Event.OnTriggerStay), OnTriggerStay);
            if (events.Contains(Event.OnTriggerExit))
                FsmEvent<Collider>.Unsubscribe<TriggerEnter>(GetOwner(Event.OnTriggerExit), OnTriggerExit);

            // On Trigger 2D
            if (events.Contains(Event.OnTriggerEnter2D))
                FsmEvent<Collider2D>.Unsubscribe<TriggerEnter2D>(GetOwner(Event.OnTriggerEnter2D), OnTriggerEnter2D);
            if (events.Contains(Event.OnTriggerStay2D))
                FsmEvent<Collider2D>.Unsubscribe<TriggerEnter2D>(GetOwner(Event.OnTriggerStay2D), OnTriggerStay2D);
            if (events.Contains(Event.OnTriggerExit2D))
                FsmEvent<Collider2D>.Unsubscribe<TriggerEnter2D>(GetOwner(Event.OnTriggerExit2D), OnTriggerExit2D);

            // On Render
            if (events.Contains(Event.OnWillRenderObject))
                FsmEvent.Unsubscribe<WillRenderObject>(GetOwner(Event.OnWillRenderObject), OnWillRenderObject);
            if (events.Contains(Event.OnPreCull))
                FsmEvent.Unsubscribe<PreCull>(GetOwner(Event.OnPreCull), OnPreCull);
            if (events.Contains(Event.OnBecameVisible))
                FsmEvent.Unsubscribe<BecameVisible>(GetOwner(Event.OnBecameVisible), OnBecameVisible);
            if (events.Contains(Event.OnBecameInvisible))
                FsmEvent.Unsubscribe<BecameInvisible>(GetOwner(Event.OnBecameInvisible), OnBecameInvisible);
            if (events.Contains(Event.OnPreRender))
                FsmEvent.Unsubscribe<PreRender>(GetOwner(Event.OnPreRender), OnPreRender);
            if (events.Contains(Event.OnRenderObject))
                FsmEvent.Unsubscribe<RenderObject>(GetOwner(Event.OnRenderObject), OnRenderObject);
            if (events.Contains(Event.OnRenderImage))
                FsmEvent.Unsubscribe<RenderImage>(GetOwner(Event.OnRenderImage), OnRenderImage);
            if (events.Contains(Event.OnPostRender))
                FsmEvent.Unsubscribe<PostRender>(GetOwner(Event.OnPostRender), OnPostRender);
        }

        // Virtual Sections.
        // Override when you want to insert your own condition.
        // e.g., if CollisionEnter then return child gameobject.
        protected virtual GameObject GetOwner(Event e)
        {
            // Unconditional.
            return gameObject;
        }

        // On Reset
        public virtual void OnReset() { }

        // On Application
        public virtual void OnResume() { }
        public virtual void OnPause() { }

        // On Update
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnLateUpdate() { }

        public virtual void OnDrawGizmos() { }
        public virtual void OnDrawGizmosSelected() { }

        // On Collision
        public virtual void OnCollisionEnter(Collision other) { }
        public virtual void OnCollisionStay(Collision other) { }
        public virtual void OnCollisionExit(Collision other) { }

        // On Collision 2D
        public virtual void OnCollisionEnter2D(Collision2D other) { }
        public virtual void OnCollisionStay2D(Collision2D other) { }
        public virtual void OnCollisionExit2D(Collision2D other) { }

        // On Trigger
        public virtual void OnTriggerEnter(Collider other) { }
        public virtual void OnTriggerStay(Collider other) { }
        public virtual void OnTriggerExit(Collider other) { }

        // On Trigger 2D
        public virtual void OnTriggerEnter2D(Collider2D other) { }
        public virtual void OnTriggerStay2D(Collider2D other) { }
        public virtual void OnTriggerExit2D(Collider2D other) { }

        // On Render
        public virtual void OnWillRenderObject() { }
        public virtual void OnPreCull() { }
        public virtual void OnBecameVisible() { }
        public virtual void OnBecameInvisible() { }
        public virtual void OnPreRender() { }
        public virtual void OnRenderObject() { }
        public virtual void OnRenderImage() { }
        public virtual void OnPostRender() { }
    }
}