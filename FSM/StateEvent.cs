using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devdayo.FSM
{
    public enum StateEvent
    {
        // Inspector Events
        OnReset,

        // Application Events
        OnResume,
        OnPause,
        OnQuit,

        // Update Events (Singleton)
        OnUpdate,
        OnFixedUpdate,
        OnLateUpdate,

        // Transform Events
        OnTransformChildrenChanged,
        OnTransformParentChanged,

        // Draw Events
        OnDrawGizmos,
        OnDrawGizmosSelected,

        // Collision Events
        OnCollisionEnter,
        OnCollisionStay,
        OnCollisionExit,

        // Collision 2D Events
        OnCollisionEnter2D,
        OnCollisionStay2D,
        OnCollisionExit2D,

        // Trigger Events
        OnTriggerEnter,
        OnTriggerStay,
        OnTriggerExit,

        // Trigger 2D Events
        OnTriggerEnter2D,
        OnTriggerStay2D,
        OnTriggerExit2D,

        // Render Events
        OnWillRenderObject,
        OnPreCull,
        OnBecameVisible,
        OnBecameInvisible,
        OnPreRender,
        OnRenderObject,
        OnRenderImage,
        OnPostRender,

        // Animator Events
        OnAnimatorIK,
        OnAnimatorMove
    }
}
