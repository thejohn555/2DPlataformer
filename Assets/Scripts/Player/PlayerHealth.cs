using System;
using System.Collections;
using BaseCharacters;
using Managers;
using UnityEditor.Toolbars;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : CharacterHealth
    {
        private PlayerMain playerMain;
        private bool isCrounching;
        private float hpHeal = 1f;
        private float timeWaitHeal=2f;
        private Coroutine healRoutine;

        protected override void Awake()
        {
            base.Awake();
            playerMain = transform.root.GetComponent<PlayerMain>();
        }

        protected void OnEnable()
        {
            playerMain.InputReader.OnCrouchStart += CrouchStart;
            playerMain.InputReader.OnCrouchEnd += CrouchEnd;
        }

        protected void OnDisable()
        {
            playerMain.InputReader.OnCrouchStart -= CrouchStart;
            playerMain.InputReader.OnCrouchEnd -= CrouchEnd;
        }

        private void CrouchStart()
        {
            if(!playerMain.CanCrouch)return;
            isCrounching = true;
            playerMain.CanAttack = false;
            playerMain.CanMove = false;
            playerMain.CanJump = false;
            healRoutine = StartCoroutine(HealRoutine());
            
        }

        private void CrouchEnd()
        {
            isCrounching = false;
            StopCoroutine(healRoutine);
            playerMain.CanAttack = true;
            playerMain.CanMove = true;
            playerMain.CanJump = true;
        }


        private void Heal(float health)
        {
            Damageable(-health);
        }
        
        public override void Damageable(float damage)
        {
            base.Damageable(damage);
            EventManager.Instance.PlayerDamage(Health/MaxHealth,playerMain.PlayerID );
        }

        protected override void CheckHealth()
        {
            if (Health <= 0)
            {
                EventManager.Instance.PlayerDead();
                AudioManager.Instance.PlaySound(1);
                Destroy(gameObject);
            }
            base.CheckHealth();
        }

        private IEnumerator HealRoutine()
        {
            while (isCrounching)
            {
                yield return new WaitForSeconds(timeWaitHeal);
                if (!isCrounching) continue;
                Heal(hpHeal);
            }
        }
    }
}
