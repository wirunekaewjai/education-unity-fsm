// Contain "GameObject" Class
using UnityEngine;

// Contain "Enum", "Type" Class
using System;

// Contain "MethodInfo" Class
using System.Reflection;

// Contain "List<T>" Class
using System.Collections.Generic;

// Contain "Callback" Class
using Devdayo.FSM.Core;

namespace Devdayo.FSM
{
    // Middle-weight Fsm State.
    // Please derived this class if you want to create state like Mono Behaviour.
    public abstract class StateBehaviour<A> : State<A> where A : MonoBehaviour
    {
        // Keep available events from reflection.
        private readonly Dictionary<StateEvent, Method> events = new Dictionary<StateEvent, Method>();

        /* 
            Please Remember !!!
            - Do not declare variable in your derived class because this state will reuse by many owner. -
        */

        // Override to custom logic while instance creating.
        protected override void OnCreate()
        {
            base.OnCreate();

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
            Type type = typeof(StateEvent);

            // false : when info.Name != Value Of Event
            // e.g., if (info.Name = "Awake") then false
            // e.g., if (info.Name = "Update") then true
            if (!Enum.IsDefined(type, info.Name))
                return;

            // Parse info.Name to event
            StateEvent e = (StateEvent)Enum.Parse(type, info.Name);

            // Create Method data.
            Method method = new Method(info.Name, this);

            // remember subscribe event.
            events[e] = method;
        }

        protected override void OnSubscribe()
        {
            base.OnSubscribe();

            GameObject target = Owner.gameObject;

            // Read override subscription events
            foreach (StateEvent e in events.Keys)
            {
                Method method = events[e];
                Subscribe(e, target, method);
            }
        }

        protected override void OnUnsubscribe()
        {
            base.OnUnsubscribe();

            GameObject target = Owner.gameObject;

            // Read override subscription events
            foreach (StateEvent e in events.Keys)
            {
                Method method = events[e];
                Unsubscribe(e, target, method);
            }
        }
        
        // On Reset
        public virtual void OnReset() { }

        // On Application
        public virtual void OnResume() { }
        public virtual void OnPause() { }
        public virtual void OnQuit() { }

        // On Update
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnLateUpdate() { }

        // On Transform
        public virtual void OnTransformChildrenChanged() { }
        public virtual void OnTransformParentChanged() { }

        // On Draw Gizmos
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

        // On Animator
        public virtual void OnAnimatorIK(int layerIndex) { }
        public virtual void OnAnimatorMove() { }
    }
}
