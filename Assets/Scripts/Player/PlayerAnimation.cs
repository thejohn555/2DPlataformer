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


        private bool attacking;
        
        private void OnEnable()
        {
            Main.InputReader.OnMoveStart += UpdateMovement;
            Main.InputReader.OnJumpStart += UpdateJump;
            Main.InputReader.OnAtackStart += UpdateAttack;
            Main.InputReader.OnCrouchStart += StartCrouching;
            Main.InputReader.OnCrouchEnd += EndCrouching;
            
        }
        private void OnDisable()
        {
            Main.InputReader.OnMoveStart -= UpdateMovement;
            Main.InputReader.OnJumpStart -= UpdateJump;
            Main.InputReader.OnAtackStart -= UpdateAttack;
            Main.InputReader.OnCrouchStart -= StartCrouching;
            Main.InputReader.OnCrouchEnd -= EndCrouching;
        }

        private void UpdateAttack()
        {
            if (!Main.CanAttack) return;
            if (attacking) return;
            StartCoroutine(AttackEnumerator());
        }

        private IEnumerator AttackEnumerator()
        {
            attacking = true;
            Main.Anim.SetTrigger(Attack);
            yield return new WaitForSeconds(1);
            attacking = false;
        }
        private void UpdateJump()
        {
            if (!Main.CanJump) return;
            
            Main.Anim.SetTrigger(Air);
        }

        private void StartCrouching()
        {
            if (!Main.CanCrouch) return;
            Main.Anim.SetBool(Crouching, true);
        }

        private void EndCrouching()
        {
            if (!Main.CanCrouch) return;
            Main.Anim.SetBool(Crouching, false);
        }

        private void UpdateMovement(float speed)
        {
            if (!Main.CanMove) return;
            Main.Anim.SetFloat(Speed, speed);
        }
    }
}
