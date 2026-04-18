using Enemies.Patrol;
using UnityEngine;

namespace Enemies
{
    public class EnemyMain : MonoBehaviour
    {
    
        public Animator Anim { get; private set; }

        public EnemyEventAnimations events { get; private set; }
        private void Awake()
        {
            Anim = GetComponentInChildren<Animator>();
            events = GetComponent<EnemyEventAnimations>();
        }
    }
}
