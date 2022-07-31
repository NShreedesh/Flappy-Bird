using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Bird Components")]
        [SerializeField]
        private new Rigidbody2D rigidbody;
        [SerializeField]
        private Animator animator;

        [Header("Other Components")]
        [SerializeField]
        private InputController inputController;

        [Header("Jump Values")]
        [SerializeField]
        private bool canJump;
        [SerializeField]
        private float jumpForce = 5f;

        [Header("Animator Tags")]
        private const string CanFly = "canFly";

        [Header("Animator Tags Hash")]
        private int _canFly;

        private void Start()
        {
            _canFly = Animator.StringToHash(CanFly);
        }

        private void Update()
        {
            if (inputController.PressInputAction.triggered)
            {
                canJump = true;
            }
            
            PlayAnimation();
        }
        
        private void FixedUpdate()
        {
            Jump();
        }

        private void Jump()
        {
            if (!canJump) return;
            
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }

        private void PlayAnimation()
        {
            var canFly = animator.GetBool(_canFly);

            switch (rigidbody.velocity.y)
            {
                case >= -4f when !canFly:
                    animator.SetBool(_canFly, true);
                    break;
                case < -4f when canFly:
                    animator.SetBool(_canFly, false);
                    break;
            }
        }
    }
}
