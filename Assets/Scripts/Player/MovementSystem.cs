using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class MovementSystem : PlayerSystem
    { 
        [SerializeField] private float moveForce;
        [SerializeField] private float gravityScale;
        [SerializeField] public float detectionGroundRadius;
        [SerializeField] private float jumpHeight;
        [SerializeField] private LayerMask whatIsGround;
        

        private bool isGrounded;
        
        private Vector3 verticalMovement;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void CheckGrounded()
        {
            isGrounded = Physics.CheckSphere(playerMain.Feet.position,detectionGroundRadius,whatIsGround);
        }

        private void ApplyGravity()
        {
            if (isGrounded && verticalMovement.y < 0)
            {
                verticalMovement.y = -2f;
            }
            else
            {
                verticalMovement.y += gravityScale * Time.deltaTime;
            }
        }

        public void Jump()
        {
            if (!isGrounded)return;
            verticalMovement.y = Mathf.Sqrt(-2 * gravityScale * jumpHeight);
        }

        public void Move(float hInput)
        {
            playerMain.Rb.AddForce(new Vector2(hInput,0)*moveForce, ForceMode2D.Force);
        }
    }
}
