using System;
using Player;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    protected PlayerMain playerMain;

    protected void Awake()
    {
        playerMain = transform.root.GetComponent<PlayerMain>();
    }
}
