using UnityEngine;
using System.Collections;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Player
{
    public class OnDied : State<PlayerFSM>
    {
        protected override void OnEnter()
        {
            Owner.StartCoroutine(OnRestartLevel());
        }


        IEnumerator OnRestartLevel()
        {
            yield return new WaitForSeconds(3);

            int level = Application.loadedLevel;
            Application.LoadLevel(level);
        }
    }
}
