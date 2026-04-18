using System;
using System.Collections;
using Interfaces;
using Managers;
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
            Main.InputReader.OnAtackStart += Atack;
        }

        private void OnDisable()
        {
            Main.InputReader.OnAtackStart -= Atack;
        }

        private void Atack()
        {
            if (!Main.CanAttack) return;
            if(atacking)return;
            AudioManager.Instance.PlaySound(2);
            StartCoroutine(AtackRoutine());
        }

        private IEnumerator AtackRoutine()
        {
            atacking = true;
            
            yield return new WaitForSeconds(0.2f);

            Collider2D result = Physics2D.OverlapCircle(Main.InteractionPoint.position,
                Main.InteractionRadius, attackingLayer);
            
            if (result!=null)
            {
                if (result.gameObject.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damageable(damage);
                }
            }
            yield return new WaitForSeconds(0.8f);
            atacking = false;
        }
        
    }
}
