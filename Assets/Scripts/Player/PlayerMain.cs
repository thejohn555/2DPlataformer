using UnityEngine;

namespace Player
{
    public class PlayerMain : MonoBehaviour
    {
        public Rigidbody2D Rb { get; protected set; }

        [field: SerializeField] public Transform Feet { get; private set; }

        
        
        private void Awake()
        {
            Rb = GetComponentInChildren<Rigidbody2D>();
        }
    }
}
