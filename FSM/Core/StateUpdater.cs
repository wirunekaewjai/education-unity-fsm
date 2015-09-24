using System;

namespace Devdayo.FSM.Core
{
    internal sealed class StateUpdater
    {
        private Action updateCallback;
        private Action fixedUpdateCallback;
        private Action lateUpdatesCallback;

        internal void Update()
        {
            if (null != updateCallback)
                updateCallback();
        }

        internal void FixedUpdate()
        {
            if (null != fixedUpdateCallback)
                fixedUpdateCallback();
        }

        internal void LateUpdate()
        {
            if (null != lateUpdatesCallback)
                lateUpdatesCallback();
        }

        internal void Destroy()
        {
            updateCallback = null;
            fixedUpdateCallback = null;
            lateUpdatesCallback = null;
        }

        public void SubscribeUpdate(Method method)
        {
            this.updateCallback += Instance.Method.Get(method);
        }

        public void UnsubscribeUpdate(Method method)
        {
            this.updateCallback -= Instance.Method.Remove(method);
        }

        public void SubscribeFixedUpdate(Method method)
        {
            this.fixedUpdateCallback += Instance.Method.Get(method);
        }

        public void UnsubscribeFixedUpdate(Method method)
        {
            this.fixedUpdateCallback -= Instance.Method.Remove(method);
        }

        public void SubscribeLateUpdate(Method method)
        {
            this.lateUpdatesCallback += Instance.Method.Get(method);
        }

        public void UnsubscribeLateUpdate(Method method)
        {
            this.lateUpdatesCallback -= Instance.Method.Remove(method);
        }
    }
}
