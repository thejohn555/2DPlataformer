using UnityEngine;

namespace Player
{
    public class PlayerMain : MonoBehaviour
    {
        public Rigidbody2D Rb { get; protected set; }

        [field: SerializeField] public Transform Feet { get; }


        
        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }
    }
}
