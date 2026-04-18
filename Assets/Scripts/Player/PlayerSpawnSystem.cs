using System;
using UnityEngine;

namespace Player
{
    public class PlayerSpawnSystem : MonoBehaviour
    {
        private Vector3 spawnPoint;

        private void Start()
        {
            SetSpawnPoint(transform.position);
        }

        public void SpawnPlayer()
        {
            transform.position = spawnPoint;
        }

        public void SetSpawnPoint(Vector3 spawnPoint)
        {
            this.spawnPoint = spawnPoint;
        }
    }
}
