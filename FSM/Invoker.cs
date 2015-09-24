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

        private const int ACTION_LIMIT = 50;
        private const int TEMP_LIMIT = 100;

        private readonly List<Data> datas = new List<Data>();
        private readonly List<Data> temps = new List<Data>();

        internal Invoker()
        {

        }

        internal void Destroy()
        {
            datas.Clear();
        }
        
        internal void Update()
        {
            float deltaTime = Time.deltaTime;
            int actionCount = 0;
            for (int i = 0; i < datas.Count;)
            {
                Data data = datas[i];
                if (data.count >= data.delay)
                {
                    data.action();
                    temps.Add(data);
                    datas.RemoveAt(i);

                    actionCount += 1;

                    if (actionCount > ACTION_LIMIT)
                    {
                        break;
                    }

                    continue;
                }

                data.count += deltaTime;
                i++;
            }

            int excess = temps.Count - TEMP_LIMIT;
            if (excess > 0)
            {
                temps.RemoveRange(TEMP_LIMIT, excess);
            }
        }
        
        
        internal System.Collections.IEnumerator RoutineUpdate()
        {
            //List<Data> deletes = new List<Data>();
            float sleepTime = Time.fixedDeltaTime * 5f;
            while (true)
            {
                float deltaTime = sleepTime;
                int actionCount = 0;
                for (int i = 0; i < datas.Count;)
                {
                    Data data = datas[i];
                    if(data.count >= data.delay)
                    {
                        data.action();

                        data.action = null;
                        data.delay = float.MaxValue;
                        data.count = 0;

                        temps.Add(data);
                        datas.RemoveAt(i);
                        
                        actionCount += 1;

                        if (actionCount > ACTION_LIMIT)
                        {
                            break;
                        }
                        
                        continue;
                    }

                    data.count += Time.deltaTime;
                    i++;
                }

                int excess = temps.Count - TEMP_LIMIT;
                if(excess > 0)
                {
                    temps.RemoveRange(TEMP_LIMIT, excess);
                }

                yield return new WaitForEndOfFrame();
            }
        }
        

        public void Invoke(Action action, float delayInSeconds)
        {
            if(temps.Count > 0)
            {
                Data data = temps[0];
                data.action = action;
                data.delay = delayInSeconds;
                data.count = 0;

                datas.Add(data);
                temps.RemoveAt(0);
            }
            else
            {
                Data data = new Data();
                data.action = action;
                data.delay = delayInSeconds;
                data.count = 0;

                datas.Add(data);
            }
        }

        public static void Schedule(Action action, float delayInSeconds)
        {
            Devdayo.FSM.Core.Instance.Invoker.Invoke(action, delayInSeconds);
        }
    }
}
