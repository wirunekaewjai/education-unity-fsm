using System;
using System.Collections.Generic;
using UnityEngine;

namespace Devdayo.FSM
{
    public sealed class Invoker
    {
        private class Data
        {
            public Action action;
            public float delay;

            public float count;
        }

        private readonly List<Data> datas = new List<Data>();
        
        internal Invoker()
        {

        }

        internal void Destroy()
        {
            datas.Clear();
        }

        internal System.Collections.IEnumerator Update()
        {
            List<Data> deletes = new List<Data>();

            while (true)
            {
                float deltaTime = Time.deltaTime;
                foreach (var data in datas)
                {
                    if(data.count >= data.delay)
                    {
                        data.action();
                        deletes.Add(data);
                    }
                    else
                    {
                        data.count += deltaTime;
                    }
                }

                foreach (var delete in deletes)
                {
                    datas.Remove(delete);
                }

                deletes.Clear();

                yield return new WaitForEndOfFrame();
            }
        }

        public void Invoke(Action action, float delay)
        {
            Data data = new Data();
            data.action = action;
            data.delay = delay;
        }

        public static void Schedule(Action action, float delay)
        {
            Devdayo.FSM.Core.Instance.Invoker.Invoke(action, delay);
        }
    }
}
