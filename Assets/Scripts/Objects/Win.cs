using System;
using Managers;
using UnityEngine;

namespace Objects
{
    public class Win : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                EventManager.Instance.Win();
                AudioManager.Instance.PlaySound(0);
            }
        }
    }
}
