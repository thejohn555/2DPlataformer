using UnityEngine;

namespace Player
{
    public class PlayerSystem : MonoBehaviour
    {
        protected PlayerMain playerMain;

        protected virtual void Awake()
        {
            playerMain = transform.root.GetComponent<PlayerMain>();
        }
    }
}
