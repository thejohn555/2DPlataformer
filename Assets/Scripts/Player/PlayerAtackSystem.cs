using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerAtackSystem : PlayerSystem
    {
        [SerializeField] private LayerMask attackingLayer;
        [SerializeField] private float damage;
        private bool atacking;

        private void OnEnable()
        {
            playerMain.InputReader.OnAtackStart += Atack;
        }

        private void OnDisable()
        {
            playerMain.InputReader.OnAtackStart -= Atack;
        }

        private void Atack()
        {
            if (!playerMain.CanAttack) return;
            if(atacking)return;
            StartCoroutine(AtackRoutine());
        }

        private IEnumerator AtackRoutine()
        {
            atacking = true;
            
            yield return new WaitForSeconds(0.5f);

            Collider2D result = Physics2D.OverlapCircle(playerMain.InteractionPoint.position,
                playerMain.InteractionRadius, attackingLayer);
            
            if (result!=null)
            {
                if (result.gameObject.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damageable(damage);
                }
            }
            atacking = false;
        }
        
    }
}
