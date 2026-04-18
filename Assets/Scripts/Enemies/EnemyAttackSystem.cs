using System;
using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public class EnemyAttackSystem : EnemySystem
    {
        [SerializeField] private float damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerHealth  player))
            {
                enemyMain.events.Attack();
                player.Damageable(damage);
            }
        }
    }
}
