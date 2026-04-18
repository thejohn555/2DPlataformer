using System;
using Enemies.Patrol;
using UnityEngine;

namespace Enemies
{
    public class EnemyAnimations : EnemySystem
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Attack = Animator.StringToHash("Attack");

        private void OnEnable()
        {
            enemyMain.events.OnUpdateMovement += UpdateSpeed;
            enemyMain.events.OnAttack += UpdateAttack;
        }
        private void OnDisable()
        {
            enemyMain.events.OnUpdateMovement -= UpdateSpeed;
            enemyMain.events.OnAttack -= UpdateAttack;
        }

        private void UpdateAttack()
        {
            enemyMain.Anim.SetTrigger(Attack);
        }


        private void UpdateSpeed(float speed)
        {
            enemyMain.Anim.SetFloat(Speed, speed);
        }
    }
}
