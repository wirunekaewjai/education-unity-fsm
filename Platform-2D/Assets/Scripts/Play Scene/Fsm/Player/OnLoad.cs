using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Player
{
	public class OnLoad : State<PlayerFSM>
	{
        protected override void OnEnter()
        {
            base.OnEnter();

            int saved = PlayerPrefs.GetInt("Saved", 0);

            if (saved == 1)
            {
                Vector3 position = Owner.transform.position;

                position.x = PlayerPrefs.GetFloat("CheckpointX", position.x);
                position.y = PlayerPrefs.GetFloat("CheckpointY", position.y);

                Owner.transform.position = position;
            }

            Machine.Go<OnGround>();
        }
    }
}
