using System;
using ScriptableObject;
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

        [SerializeField] private InputReaderSO inputReader;
        

        [SerializeField] private bool isGrounded;
        
        [SerializeField] private Vector2 verticalMovement;
        
        [SerializeField] private Vector2 movementVector;
        

        private void OnEnable()
        {
            inputReader.Initialize();
            inputReader.OnJumpStart += Jump;
            inputReader.OnMoveStart += UpdateMovement;
        }

        private void OnDisable()
        {
            inputReader.OnJumpStart -= Jump;
            inputReader.OnMoveStart -= UpdateMovement;
        }

        private void Update()
        {
            CheckGrounded();
            ApplyGravity();
            Move();
            
        }
        
        private void CheckGrounded()
        {
            isGrounded = Physics2D.OverlapCircle(playerMain.Feet.position,detectionGroundRadius,whatIsGround);
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

        private void Jump()
        {
            if (!isGrounded)return;
            verticalMovement.y = Mathf.Sqrt(-2 * gravityScale * jumpHeight);
        }

        private void UpdateMovement(float hInput)
        {
            movementVector = new Vector2(hInput * moveForce, 0);
        }

        private void Move()
        {
            playerMain.Rb.AddForce(movementVector + verticalMovement, ForceMode2D.Force);
        }
    }
}
