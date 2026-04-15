using BaseCharacters;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : CharacterHealth
    {
        protected PlayerMain playerMain;
        protected override void Awake()
        {
            base.Awake();
            playerMain = transform.root.GetComponent<PlayerMain>();
        }

        public override void Damageable(float damage)
        {
            base.Damageable(damage);
            EventManager.Instance.PlayerDamage(Health/MaxHealth,playerMain.PlayerID );
        }
    }
}
