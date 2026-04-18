using UnityEngine;

namespace Enemies
{
    public class EnemySystem : MonoBehaviour
    {
        protected EnemyMain enemyMain;

        protected virtual void Awake()
        {
            enemyMain = transform.root.GetComponent<EnemyMain>();
        }
    }
}
