using UnityEngine;
using Devdayo.FSM;

namespace Devdayo.Platformer2D.Player
{
    public class PlayerFSM : MonoBehaviour
    {
        private StateMachine<PlayerFSM> machine;

        internal Rigidbody2D rigidbody;
        internal Animator animator;

        internal float gravityScale;

        public Collider2D boxCollider;
        public Collider2D polyCollider;

        public float moveSpeed = 3;
        public float jumpPower = 6;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            machine = new StateMachine<PlayerFSM>(this);
        }

        void Start()
        {
            machine.Go<OnLoad>();
        }
        
        public void UpdateHorizontal()
        {
            float h = Input.GetAxisRaw("Horizontal");

            // Calculate Move Velocity
            Vector3 velocity = rigidbody.velocity;
            velocity.x = moveSpeed * h;

            // Apply Move Velocity
            rigidbody.velocity = velocity;

            // Apply Running Animation | Idle
            animator.SetBool("Running", h != 0);

            // Moving ?
            if (velocity.x == 0)
                return;

            // Calculate Face Direction
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(velocity.x);

            // Flip Face Direction
            transform.localScale = scale;
        }

        public void UpdateVertical()
        {
            float v = Input.GetAxisRaw("Vertical");

            // Calculate Move Velocity
            Vector3 velocity = rigidbody.velocity;
            velocity.y = moveSpeed * v;

            // Apply Move Velocity
            rigidbody.velocity = velocity;
        }

        public void Jump(bool ignoreInput)
        {
            if (ignoreInput || Input.GetKeyDown(KeyCode.Space))
            {
                // Calculate Move Velocity
                Vector3 velocity = rigidbody.velocity;
                velocity.y = jumpPower;

                // Apply Move Velocity
                rigidbody.velocity = velocity;
            }
        }

    }
}