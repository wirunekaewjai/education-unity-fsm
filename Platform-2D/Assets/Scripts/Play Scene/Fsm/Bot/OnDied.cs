using System;
using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Bot
{
    public class OnDied : State<BotFSM>
    {
        protected override void OnEnter()
        {
            base.OnEnter();

            GameObject.Destroy(Owner.gameObject, 3);
        }
    }
}
