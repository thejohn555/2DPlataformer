using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : PlayerSystem
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Air = Animator.StringToHash("Air");
        private static readonly int Crouching = Animator.StringToHash("Crouching");


        private void OnEnable()
        {
            playerMain.InputReader.OnMoveStart += UpdateMovement;
            playerMain.InputReader.OnJumpStart += UpdateJump;
            playerMain.InputReader.OnAtackStart += UpdateAttack;
            playerMain.InputReader.OnCrouchStart += StartCrouching;
            playerMain.InputReader.OnCrouchEnd += EndCrouching;
            
        }
        private void OnDisable()
        {
            playerMain.InputReader.OnMoveStart -= UpdateMovement;
            playerMain.InputReader.OnJumpStart -= UpdateJump;
            playerMain.InputReader.OnAtackStart -= UpdateAttack;
            playerMain.InputReader.OnCrouchStart -= StartCrouching;
            playerMain.InputReader.OnCrouchEnd -= EndCrouching;
        }

        private void UpdateAttack()
        {
            if (!playerMain.CanAttack) return;
            playerMain.Anim.SetTrigger(Attack);
        }

        private void UpdateJump()
        {
            if (!playerMain.CanJump) return;
            
            playerMain.Anim.SetTrigger(Air);
        }

        private void StartCrouching()
        {
            if (!playerMain.CanCrouch) return;
            playerMain.Anim.SetBool(Crouching, true);
        }

        private void EndCrouching()
        {
            if (!playerMain.CanCrouch) return;
            playerMain.Anim.SetBool(Crouching, false);
        }

        private void UpdateMovement(float speed)
        {
            if (!playerMain.CanMove) return;
            playerMain.Anim.SetFloat(Speed, speed);
        }
    }
}
