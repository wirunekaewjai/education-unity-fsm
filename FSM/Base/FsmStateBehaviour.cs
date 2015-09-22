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

            // On Reset
            Subscribe<Reseter>(Event.OnReset, OnReset);

            // On Application
            Subscribe<Resumer>(Event.OnResume, OnResume);
            Subscribe<Pauser>(Event.OnPause, OnPause);

            // On Update
            Subscribe<Updater>(Event.OnUpdate, OnUpdate);
            Subscribe<FixedUpdater>(Event.OnFixedUpdate, OnFixedUpdate);
            Subscribe<LateUpdater>(Event.OnLateUpdate, OnLateUpdate);

            // On Draw
            Subscribe<DrawGizmos>(Event.OnDrawGizmos, OnDrawGizmos);
            Subscribe<DrawGizmosSelected>(Event.OnDrawGizmosSelected, OnDrawGizmosSelected);
            
            // On Collision
            Subscribe<CollisionEnter, Collision>(Event.OnCollisionEnter, OnCollisionEnter);
            Subscribe<CollisionStay, Collision>(Event.OnCollisionStay, OnCollisionStay);
            Subscribe<CollisionExit, Collision>(Event.OnCollisionExit, OnCollisionExit);

            // On Collision 2D
            Subscribe<CollisionEnter2D, Collision2D>(Event.OnCollisionEnter2D, OnCollisionEnter2D);
            Subscribe<CollisionStay2D, Collision2D>(Event.OnCollisionStay2D, OnCollisionStay2D);
            Subscribe<CollisionExit2D, Collision2D>(Event.OnCollisionExit2D, OnCollisionExit2D);

            // On Trigger
            Subscribe<TriggerEnter, Collider>(Event.OnTriggerEnter, OnTriggerEnter);
            Subscribe<TriggerStay, Collider>(Event.OnTriggerStay, OnTriggerStay);
            Subscribe<TriggerExit, Collider>(Event.OnTriggerExit, OnTriggerExit);

            // On Trigger 2D
            Subscribe<TriggerEnter2D, Collider2D>(Event.OnTriggerEnter2D, OnTriggerEnter2D);
            Subscribe<TriggerStay2D, Collider2D>(Event.OnTriggerStay2D, OnTriggerStay2D);
            Subscribe<TriggerExit2D, Collider2D>(Event.OnTriggerExit2D, OnTriggerExit2D);

            // On Render
            Subscribe<WillRenderObject>(Event.OnWillRenderObject, OnWillRenderObject);
            Subscribe<PreCull>(Event.OnPreCull, OnPreCull);
            Subscribe<BecameVisible>(Event.OnBecameVisible, OnBecameVisible);
            Subscribe<BecameInvisible>(Event.OnBecameInvisible, OnBecameInvisible);
            Subscribe<PreRender>(Event.OnPreRender, OnPreRender);
            Subscribe<RenderObject>(Event.OnRenderObject, OnRenderObject);
            Subscribe<RenderImage, RenderTexture, RenderTexture>(Event.OnRenderImage, OnRenderImage);
            Subscribe<PostRender>(Event.OnPostRender, OnPostRender);
        }

        // Override from FsmState.cs
        public override void OnUnsubscribe()
        {
            // Call FsmState.OnSubscribe
            base.OnUnsubscribe();
            
            // On Reset
            Unsubscribe<Reseter>(Event.OnReset, OnReset);

            // On Application
            Unsubscribe<Resumer>(Event.OnResume, OnResume);
            Unsubscribe<Pauser>(Event.OnPause, OnPause);

            // On Update
            Unsubscribe<Updater>(Event.OnUpdate, OnUpdate);
            Unsubscribe<FixedUpdater>(Event.OnFixedUpdate, OnFixedUpdate);
            Unsubscribe<LateUpdater>(Event.OnLateUpdate, OnLateUpdate);

            // On Draw
            Unsubscribe<DrawGizmos>(Event.OnDrawGizmos, OnDrawGizmos);
            Unsubscribe<DrawGizmosSelected>(Event.OnDrawGizmosSelected, OnDrawGizmosSelected);

            // On Collision
            Unsubscribe<CollisionEnter, Collision>(Event.OnCollisionEnter, OnCollisionEnter);
            Unsubscribe<CollisionStay, Collision>(Event.OnCollisionStay, OnCollisionStay);
            Unsubscribe<CollisionExit, Collision>(Event.OnCollisionExit, OnCollisionExit);

            // On Collision 2D
            Unsubscribe<CollisionEnter2D, Collision2D>(Event.OnCollisionEnter2D, OnCollisionEnter2D);
            Unsubscribe<CollisionStay2D, Collision2D>(Event.OnCollisionStay2D, OnCollisionStay2D);
            Unsubscribe<CollisionExit2D, Collision2D>(Event.OnCollisionExit2D, OnCollisionExit2D);

            // On Trigger
            Unsubscribe<TriggerEnter, Collider>(Event.OnTriggerEnter, OnTriggerEnter);
            Unsubscribe<TriggerStay, Collider>(Event.OnTriggerStay, OnTriggerStay);
            Unsubscribe<TriggerExit, Collider>(Event.OnTriggerExit, OnTriggerExit);

            // On Trigger 2D
            Unsubscribe<TriggerEnter2D, Collider2D>(Event.OnTriggerEnter2D, OnTriggerEnter2D);
            Unsubscribe<TriggerStay2D, Collider2D>(Event.OnTriggerStay2D, OnTriggerStay2D);
            Unsubscribe<TriggerExit2D, Collider2D>(Event.OnTriggerExit2D, OnTriggerExit2D);

            // On Render
            Unsubscribe<WillRenderObject>(Event.OnWillRenderObject, OnWillRenderObject);
            Unsubscribe<PreCull>(Event.OnPreCull, OnPreCull);
            Unsubscribe<BecameVisible>(Event.OnBecameVisible, OnBecameVisible);
            Unsubscribe<BecameInvisible>(Event.OnBecameInvisible, OnBecameInvisible);
            Unsubscribe<PreRender>(Event.OnPreRender, OnPreRender);
            Unsubscribe<RenderObject>(Event.OnRenderObject, OnRenderObject);
            Unsubscribe<RenderImage, RenderTexture, RenderTexture>(Event.OnRenderImage, OnRenderImage);
            Unsubscribe<PostRender>(Event.OnPostRender, OnPostRender);
        }

        protected void Subscribe<T>(Event e, Action a) where T : FsmEvent
        {
            if (!events.Contains(e))
                return;

            GameObject obs = GetObservable(e);
            FsmEvent.Subscribe<T>(obs, a);
        }
        protected void Subscribe<T, A>(Event e, Action<A> a) where T : FsmEvent<A>
        {
            if (!events.Contains(e))
                return;

            GameObject obs = GetObservable(e);
            FsmEvent<A>.Subscribe<T>(obs, a);
        }
        protected void Subscribe<T, A, B>(Event e, Action<A, B> a) where T : FsmEvent<A, B>
        {
            if (!events.Contains(e))
                return;

            GameObject obs = GetObservable(e);
            FsmEvent<A, B>.Subscribe<T>(obs, a);
        }

        protected void Unsubscribe<T>(Event e, Action a) where T : FsmEvent
        {
            if (!events.Contains(e))
                return;

            GameObject obs = GetObservable(e);
            FsmEvent.Unsubscribe<T>(obs, a);
        }
        protected void Unsubscribe<T, A>(Event e, Action<A> a) where T : FsmEvent<A>
        {
            if (!events.Contains(e))
                return;

            GameObject obs = GetObservable(e);
            FsmEvent<A>.Unsubscribe<T>(obs, a);
        }
        protected void Unsubscribe<T, A, B>(Event e, Action<A, B> a) where T : FsmEvent<A, B>
        {
            if (!events.Contains(e))
                return;

            GameObject obs = GetObservable(e);
            FsmEvent<A, B>.Unsubscribe<T>(obs, a);
        }

        // Virtual Sections.
        // Override when you want to insert your own condition.
        // e.g., if CollisionEnter then return child gameobject.
        protected virtual GameObject GetObservable(Event e)
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
        public virtual void OnRenderImage(RenderTexture src, RenderTexture dest) { }
        public virtual void OnPostRender() { }
    }
}