using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Bird Components")]
        [SerializeField]
        private new Rigidbody2D rigidbody;

        [Header("Other Components")]
        [SerializeField]
        private InputController inputController;

        [Header("Jump Values")]
        [SerializeField]
        private bool canJump;
        [SerializeField]
        private float jumpForce = 5f;

        private void Update()
        {
            if (inputController.PressInputAction.triggered)
            {
                canJump = true;
            }
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
    }
}
