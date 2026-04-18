using System;
using Managers;
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
            Main.InputReader.Initialize();
            Main.InputReader.OnJumpStart += Jump;
            Main.InputReader.OnMoveStart += UpdateMovement;
            EventManager.Instance.OnPlayerDeath += StopInputs;
            EventManager.Instance.OnPlayerWin += StopInputs;
            EventManager.Instance.OnlevelStart += StartInputs;
        }
        private void OnDisable()
        {
            Main.InputReader.OnJumpStart -= Jump;
            Main.InputReader.OnMoveStart -= UpdateMovement;
            EventManager.Instance.OnPlayerDeath -= StopInputs;
            EventManager.Instance.OnPlayerWin -= StopInputs;
            EventManager.Instance.OnlevelStart -= StartInputs;
        }

        private void Start()
        {
            EventManager.Instance.StartLevel();
        }
        private void StopInputs()
        {
            Main.InputReader.PlayerActions.GamePlayActions.Disable();
        }


        private void StartInputs()
        {
            Main.InputReader.PlayerActions.GamePlayActions.Enable();
        }

        private void FixedUpdate()
        {
            CheckGrounded();
            ApplyGravity();
            Move();
            
        }
        
        private void CheckGrounded()
        {
            isGrounded = Physics2D.OverlapCircle(Main.Feet.position,detectionGroundRadius,whatIsGround);
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
                if (verticalMovement.y < -10f)
                {
                    verticalMovement.y = -10f;
                }
            }
        }

        private void Jump()
        {
            if (!Main.CanJump) return;
            if (!isGrounded)return;
            verticalMovement.y = jumpHeight;
            AudioManager.Instance.PlaySound(3);
        }

        private void UpdateMovement(float hInput)
        {
            if (!Main.CanMove) return;
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
            Main.Rb.AddForce(movementVector, ForceMode2D.Force);
            Main.Rb.AddForce(verticalMovement, ForceMode2D.Impulse);
        }
    }
}
