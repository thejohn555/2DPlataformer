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

        

        [SerializeField] private bool isGrounded;
        
        [SerializeField] private Vector2 verticalMovement;
        
        [SerializeField] private Vector2 movementVector;
        

        private void OnEnable()
        {
            playerMain.InputReader.Initialize();
            playerMain.InputReader.OnJumpStart += Jump;
            playerMain.InputReader.OnMoveStart += UpdateMovement;
        }

        private void OnDisable()
        {
            playerMain.InputReader.OnJumpStart -= Jump;
            playerMain.InputReader.OnMoveStart -= UpdateMovement;
        }

        private void FixedUpdate()
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
            verticalMovement.y = jumpHeight;
        }

        private void UpdateMovement(float hInput)
        {
            movementVector = new Vector2(hInput * moveForce, 0);
            Rotate(hInput);
        }

        private void Rotate(float hInput)
        {
            if (hInput < 0)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else if (hInput > 0 && transform.eulerAngles.z == 0) 
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }

        private void Move()
        {
            // //1. al dar espacio -- quito gravedad -- al terminar los 2 seg. vuelves a acti
            // playerMain.Rb.linearVelocity =  Vector3.up * 2;
            playerMain.Rb.AddForce(movementVector, ForceMode2D.Force);
            playerMain.Rb.AddForce(verticalMovement, ForceMode2D.Impulse);
        }
    }
}
