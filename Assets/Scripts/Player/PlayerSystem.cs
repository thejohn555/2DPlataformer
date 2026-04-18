using UnityEngine;

namespace Player
{
    public class PlayerSystem : MonoBehaviour
    {
        protected PlayerMain Main { get; set; }

        protected virtual void Awake()
        {
            Main = transform.root.GetComponent<PlayerMain>();
        }
    }
}
