using UnityEngine;

namespace Player
{
    public class PlayerAnimation : PlayerSystem
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Air = Animator.StringToHash("Air");


        private void OnEnable()
        {
            playerMain.InputReader.OnMoveStart += UpdateMovement;
            playerMain.InputReader.OnJumpStart += UpdateJump;
            playerMain.InputReader.OnAtackStart += UpdateAttack;
            
        }
        private void OnDisable()
        {
            playerMain.InputReader.OnMoveStart -= UpdateMovement;
            playerMain.InputReader.OnJumpStart -= UpdateJump;
            playerMain.InputReader.OnAtackStart -= UpdateAttack;
        }

        private void UpdateAttack()
        {
            playerMain.Anim.SetTrigger(Attack);
        }

        private void UpdateJump()
        {
            playerMain.Anim.SetTrigger(Air);
        }


        private void UpdateMovement(float speed)
        {
            playerMain.Anim.SetFloat(Speed, speed);
        }
        
    }
}
