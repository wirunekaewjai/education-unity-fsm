using System;
using UnityEngine;
using Devdayo.FSM.Core;

namespace Devdayo.FSM.Event
{
    public abstract class Observer
    {
        protected virtual void OnSubscribe() { }
        protected virtual void OnUnsubscribe() { }

        /*
        // Subscribe Methods
        public virtual void Subscribe(StateEvent e, Method method)
        {
            
            // Update Events
            if (e == StateEvent.OnUpdate)
            {
                Instance.Updater.SubscribeUpdate(method);
            }
            else if (e == StateEvent.OnFixedUpdate)
            {
                Instance.Updater.SubscribeFixedUpdate(method);
            }
            else if (e == StateEvent.OnLateUpdate)
            {
                Instance.Updater.SubscribeLateUpdate(method);
            }
            
        }
        */
        public virtual void Subscribe(StateEvent e, GameObject target, Method method)
        {
            
            // Update Events
            if (e == StateEvent.OnUpdate)
            {
                Instance.Updater.SubscribeUpdate(method);
                //Observable.Subscribe<BehaviourUpdate>(target, method);
            }
            else if (e == StateEvent.OnFixedUpdate)
            {
                Instance.Updater.SubscribeFixedUpdate(method);
                //Observable.Subscribe<BehaviourFixedUpdate>(target, method);
            }
            else if (e == StateEvent.OnLateUpdate)
            {
                Instance.Updater.SubscribeLateUpdate(method);
                //Observable.Subscribe<BehaviourLateUpdate>(target, method);
            }

            // Inspector Events
            else
            if (e == StateEvent.OnReset)
            {
                Observable.Subscribe<InspectorReset>(target, method);
            }

            // Application Events
            else if (e == StateEvent.OnResume)
            {
                Observable.Subscribe<AppResume>(target, method);
            }
            else if (e == StateEvent.OnPause)
            {
                Observable.Subscribe<AppPause>(target, method);
            }
            else if (e == StateEvent.OnQuit)
            {
                Observable.Subscribe<AppQuit>(target, method);
            }

            // Transform Events
            else if (e == StateEvent.OnTransformParentChanged)
            {
                Observable.Subscribe<TransformParentChange>(target, method);
            }
            else if (e == StateEvent.OnTransformChildrenChanged)
            {
                Observable.Subscribe<TransformChildrenChange>(target, method);
            }

            // Draw Events
            else if (e == StateEvent.OnDrawGizmos)
            {
                Observable.Subscribe<DrawGizmos>(target, method);
            }
            else if (e == StateEvent.OnDrawGizmosSelected)
            {
                Observable.Subscribe<DrawGizmosSelected>(target, method);
            }

            // Collision Events
            else if (e == StateEvent.OnCollisionEnter)
            {
                Observable<Collision>.Subscribe<CollisionEnter>(target, method);
            }
            else if (e == StateEvent.OnCollisionStay)
            {
                Observable<Collision>.Subscribe<CollisionStay>(target, method);
            }
            else if (e == StateEvent.OnCollisionExit)
            {
                Observable<Collision>.Subscribe<CollisionExit>(target, method);
            }

            // Collision 2D Events
            else if (e == StateEvent.OnCollisionEnter2D)
            {
                Observable<Collision2D>.Subscribe<CollisionEnter2D>(target, method);
            }
            else if (e == StateEvent.OnCollisionStay2D)
            {
                Observable<Collision2D>.Subscribe<CollisionStay2D>(target, method);
            }
            else if (e == StateEvent.OnCollisionExit2D)
            {
                Observable<Collision2D>.Subscribe<CollisionExit2D>(target, method);
            }

            // Trigger Events
            else if (e == StateEvent.OnTriggerEnter)
            {
                Observable<Collider>.Subscribe<TriggerEnter>(target, method);
            }
            else if (e == StateEvent.OnTriggerStay)
            {
                Observable<Collider>.Subscribe<TriggerStay>(target, method);
            }
            else if (e == StateEvent.OnTriggerExit)
            {
                Observable<Collider>.Subscribe<TriggerExit>(target, method);
            }

            // Trigger 2D Events
            else if (e == StateEvent.OnTriggerEnter2D)
            {
                Observable<Collider2D>.Subscribe<TriggerEnter2D>(target, method);
            }
            else if (e == StateEvent.OnTriggerStay2D)
            {
                Observable<Collider2D>.Subscribe<TriggerStay2D>(target, method);
            }
            else if (e == StateEvent.OnTriggerExit2D)
            {
                Observable<Collider2D>.Subscribe<TriggerExit2D>(target, method);
            }

            // Render Events
            else if (e == StateEvent.OnWillRenderObject)
            {
                Observable.Subscribe<WillRenderObject>(target, method);
            }
            else if (e == StateEvent.OnPreCull)
            {
                Observable.Subscribe<PreCull>(target, method);
            }
            else if (e == StateEvent.OnBecameVisible)
            {
                Observable.Subscribe<BecameVisible>(target, method);
            }
            else if (e == StateEvent.OnBecameInvisible)
            {
                Observable.Subscribe<BecameInvisible>(target, method);
            }
            else if (e == StateEvent.OnPreRender)
            {
                Observable.Subscribe<PreRender>(target, method);
            }
            else if (e == StateEvent.OnRenderObject)
            {
                Observable.Subscribe<RenderObject>(target, method);
            }
            else if (e == StateEvent.OnRenderImage)
            {
                Observable<RenderTexture, RenderTexture>.Subscribe<RenderImage>(target, method);
            }
            else if (e == StateEvent.OnPostRender)
            {
                Observable.Subscribe<PostRender>(target, method);
            }

            // Animator Events
            else if (e == StateEvent.OnAnimatorIK)
            {
                Observable<int>.Subscribe<AnimatorIK>(target, method);
            }
            else if (e == StateEvent.OnAnimatorMove)
            {
                Observable.Subscribe<AnimatorMove>(target, method);
            }
        }

        /*
        // Unsubscribe Methods
        public virtual void Unsubscribe(StateEvent e, Method method)
        {
            
            // Update Events
            if (e == StateEvent.OnUpdate)
            {
                //Instance.Updater.UnsubscribeUpdate(method);
            }
            else if (e == StateEvent.OnFixedUpdate)
            {
                Instance.Updater.UnsubscribeFixedUpdate(method);
            }
            else if (e == StateEvent.OnLateUpdate)
            {
                Instance.Updater.UnsubscribeLateUpdate(method);
            }
            
        }
        */

        public virtual void Unsubscribe(StateEvent e, GameObject target, Method method)
        {
            
            // Update Events
            if (e == StateEvent.OnUpdate)
            {
                Instance.Updater.UnsubscribeUpdate(method);
                //Observable.Unsubscribe<BehaviourUpdate>(target, method);
            }
            else if (e == StateEvent.OnFixedUpdate)
            {
                Instance.Updater.UnsubscribeFixedUpdate(method);
                //Observable.Unsubscribe<BehaviourFixedUpdate>(target, method);
            }
            else if (e == StateEvent.OnLateUpdate)
            {
                Instance.Updater.UnsubscribeLateUpdate(method);
                //Observable.Unsubscribe<BehaviourLateUpdate>(target, method);
            }

            // Inspector Events
            else
            if (e == StateEvent.OnReset)
            {
                Observable.Unsubscribe<InspectorReset>(target, method);
            }

            // Application Events
            else if (e == StateEvent.OnResume)
            {
                Observable.Unsubscribe<AppResume>(target, method);
            }
            else if (e == StateEvent.OnPause)
            {
                Observable.Unsubscribe<AppPause>(target, method);
            }
            else if (e == StateEvent.OnQuit)
            {
                Observable.Unsubscribe<AppQuit>(target, method);
            }

            // Transform Events
            else if (e == StateEvent.OnTransformParentChanged)
            {
                Observable.Unsubscribe<TransformParentChange>(target, method);
            }
            else if (e == StateEvent.OnTransformChildrenChanged)
            {
                Observable.Unsubscribe<TransformChildrenChange>(target, method);
            }

            // Draw Events
            else if (e == StateEvent.OnDrawGizmos)
            {
                Observable.Unsubscribe<DrawGizmos>(target, method);
            }
            else if (e == StateEvent.OnDrawGizmosSelected)
            {
                Observable.Unsubscribe<DrawGizmosSelected>(target, method);
            }

            // Collision Events
            else if (e == StateEvent.OnCollisionEnter)
            {
                Observable<Collision>.Unsubscribe<CollisionEnter>(target, method);
            }
            else if (e == StateEvent.OnCollisionStay)
            {
                Observable<Collision>.Unsubscribe<CollisionStay>(target, method);
            }
            else if (e == StateEvent.OnCollisionExit)
            {
                Observable<Collision>.Unsubscribe<CollisionExit>(target, method);
            }

            // Collision 2D Events
            else if (e == StateEvent.OnCollisionEnter2D)
            {
                Observable<Collision2D>.Unsubscribe<CollisionEnter2D>(target, method);
            }
            else if (e == StateEvent.OnCollisionStay2D)
            {
                Observable<Collision2D>.Unsubscribe<CollisionStay2D>(target, method);
            }
            else if (e == StateEvent.OnCollisionExit2D)
            {
                Observable<Collision2D>.Unsubscribe<CollisionExit2D>(target, method);
            }

            // Trigger Events
            else if (e == StateEvent.OnTriggerEnter)
            {
                Observable<Collider>.Unsubscribe<TriggerEnter>(target, method);
            }
            else if (e == StateEvent.OnTriggerStay)
            {
                Observable<Collider>.Unsubscribe<TriggerStay>(target, method);
            }
            else if (e == StateEvent.OnTriggerExit)
            {
                Observable<Collider>.Unsubscribe<TriggerExit>(target, method);
            }

            // Trigger 2D Events
            else if (e == StateEvent.OnTriggerEnter2D)
            {
                Observable<Collider2D>.Unsubscribe<TriggerEnter2D>(target, method);
            }
            else if (e == StateEvent.OnTriggerStay2D)
            {
                Observable<Collider2D>.Unsubscribe<TriggerStay2D>(target, method);
            }
            else if (e == StateEvent.OnTriggerExit2D)
            {
                Observable<Collider2D>.Unsubscribe<TriggerExit2D>(target, method);
            }

            // Render Events
            else if (e == StateEvent.OnWillRenderObject)
            {
                Observable.Unsubscribe<WillRenderObject>(target, method);
            }
            else if (e == StateEvent.OnPreCull)
            {
                Observable.Unsubscribe<PreCull>(target, method);
            }
            else if (e == StateEvent.OnBecameVisible)
            {
                Observable.Unsubscribe<BecameVisible>(target, method);
            }
            else if (e == StateEvent.OnBecameInvisible)
            {
                Observable.Unsubscribe<BecameInvisible>(target, method);
            }
            else if (e == StateEvent.OnPreRender)
            {
                Observable.Unsubscribe<PreRender>(target, method);
            }
            else if (e == StateEvent.OnRenderObject)
            {
                Observable.Unsubscribe<RenderObject>(target, method);
            }
            else if (e == StateEvent.OnRenderImage)
            {
                Observable<RenderTexture, RenderTexture>.Unsubscribe<RenderImage>(target, method);
            }
            else if (e == StateEvent.OnPostRender)
            {
                Observable.Unsubscribe<PostRender>(target, method);
            }

            // Animator Events
            else if (e == StateEvent.OnAnimatorIK)
            {
                Observable<int>.Unsubscribe<AnimatorIK>(target, method);
            }
            else if (e == StateEvent.OnAnimatorMove)
            {
                Observable.Unsubscribe<AnimatorMove>(target, method);
            }
        }
    }
}
