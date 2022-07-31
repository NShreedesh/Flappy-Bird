using Manager;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField]
        private GameManager gameManager;
        
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
        private float jumpForce = 5f;
        private bool _canJump;

        [Header("Animator Tags")]
        private const string CanFly = "canFly";

        [Header("Animator Tags Hash")]
        private int _canFly;

        [Header("Rotation Values")]
        [SerializeField]
        private float rotationSpeed = 5;

        private void Start()
        {
            _canFly = Animator.StringToHash(CanFly);
        }

        private void Update()
        {
            if(gameManager.IsPlayerDead) return;
            
            if (inputController.PressInputAction.triggered)
            {
                _canJump = true;
            }
            
            PlayAnimation();
        }
        
        private void FixedUpdate()
        {
            if(gameManager.IsPlayerDead) return;
            
            Jump();
            RotateBird();
        }

        private void Jump()
        {
            if (!_canJump) return;
            
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _canJump = false;
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

        private void RotateBird()
        {
            var targetRotation = rigidbody.velocity.y >= -4f ? new Vector3(0, 0, 20) : new Vector3(0, 0, -20);
            var rotate = Quaternion.Slerp(transform.rotation, quaternion.Euler(targetRotation), Time.fixedDeltaTime * rotationSpeed);
            rigidbody.SetRotation(rotate);
        }
    }
}
