using UnityEngine;

namespace Devdayo.FSM.Core
{
    public sealed class Method
    {
        public string name;
        public object owner;

        public Method(string name, object owner)
        {
            this.name = name;
            this.owner = owner;
        }
    }
}
