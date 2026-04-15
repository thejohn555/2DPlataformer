using UnityEngine;

namespace Player
{
    public class PlayerAnimation : PlayerSystem
    {
        private static readonly int Speed1 = Animator.StringToHash("Speed");
        private Animator animator;

        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            playerMain.InputReader.OnMoveStart += UpdateMovement;
        }

        private void UpdateMovement(float speed)
        {
            animator.SetFloat(Speed1, speed);
        }
    }
}
