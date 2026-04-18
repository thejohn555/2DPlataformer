using System.Collections;
using Interfaces;
using UnityEngine;

namespace BaseCharacters
{
    public class CharacterHealth : MonoBehaviour,IDamageable
    {
        [field: SerializeField]protected float Health { get; private set; }
        [field: SerializeField]protected float MaxHealth { get; private set; }

        protected virtual void Awake()
        {
            Health = MaxHealth;
        }

        public virtual void Damageable(float damage)
        {
            Health -= damage;
            CheckHealth();
        }

        protected virtual void CheckHealth()
        {
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
            else if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }
}
