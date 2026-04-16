using ScriptableObject;
using UnityEngine;

namespace Player
{
    public class PlayerMain : MonoBehaviour
    {
        [field: SerializeField] public float InteractionRadius { get; private set; }
        [field: SerializeField] public Transform InteractionPoint { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        public Animator Anim { get; private set; }


        [field: SerializeField] public InputReaderSO InputReader { get; private set; }

        [field: SerializeField] public Transform Feet { get; private set; }

        public enum IDPlayer
        {
            Player1,
            Player2,
        }
        
        [field: SerializeField] public IDPlayer PlayerID{ get; private set; }
        
        private void Awake()
        {
            Rb = GetComponentInChildren<Rigidbody2D>();
            Anim = GetComponentInChildren<Animator>();
            
        }
    }
}
