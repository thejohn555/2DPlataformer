using System;
using UnityEngine;

namespace Enemies
{
    public class EnemyEventAnimations : MonoBehaviour
    {
        public event Action<float> OnUpdateMovement;
        public event Action OnAttack;

        public virtual void UpdateMovement(float speed)
        {
            OnUpdateMovement?.Invoke(speed);
        }

        public virtual void Attack()
        {
            OnAttack?.Invoke();
        }
    }
}
