using Player;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerSpawnSystem player))
        {
            player.SetSpawnPoint(transform.position);
        }
    }
}
