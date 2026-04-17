using System.Collections;
using BaseCharacters;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : CharacterHealth
    {
        protected PlayerMain playerMain;
        private bool isCrounching;
        private float hpHeal = 1f;
        private float timeWaitHeal=2f;

        protected override void Awake()
        {
            base.Awake();
            playerMain = transform.root.GetComponent<PlayerMain>();
        }

        public void Heal(float health)
        {
            Damageable(-health);
        }
        
        public override void Damageable(float damage)
        {
            base.Damageable(damage);
            EventManager.Instance.PlayerDamage(Health/MaxHealth,playerMain.PlayerID );
        }

        public IEnumerator HealRoutine()
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
