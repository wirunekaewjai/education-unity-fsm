using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Bot
{
    [RequireComponent(typeof(Tween))]
    public class BotFSM : MonoBehaviour
    {
        private StateMachine<BotFSM> machine;

        internal Rigidbody2D rigidbody;
        internal Animator animator;
        
        public Collider2D boxCollider;
        public Collider2D polyCollider;

        public Tween tween;

        public float moveSpeed = 3;
        public float jumpPower = 6;

        public bool immortal = false;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            machine = new StateMachine<BotFSM>(this);
        }

        void Start()
        {
            machine.Go<OnMove>();
        }
        
    }
}