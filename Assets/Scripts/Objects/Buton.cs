using System;
using UnityEngine;

public class Buton : MonoBehaviour
{
    [SerializeField] private GameObject Wall;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Wall.GetComponent<Collider2D>().enabled = false;
        if (Wall.TryGetComponent(out SpriteRenderer sprite))
        {
            sprite.enabled = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Wall.GetComponent<Collider2D>().enabled = true;
        if (Wall.TryGetComponent(out SpriteRenderer sprite))
        {
            sprite.enabled = true;
        }
    }
}
