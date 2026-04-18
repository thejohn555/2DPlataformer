using Player;
using UnityEngine;

namespace Objects
{
    public class Kill : MonoBehaviour
    {
        [SerializeField] private float damage;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            other.GetComponent<PlayerHealth>().Damageable(damage);
            other.GetComponentInChildren<PlayerSpawnSystem>().SpawnPlayer();
        }
    }
}
