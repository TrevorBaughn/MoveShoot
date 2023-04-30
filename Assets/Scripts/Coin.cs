using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IKillable
{
    [SerializeField] private int score;

    void Start()
    {
        GameManager.instance.collectables.Add(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().score += score;
            Die();
        }
    }

    public void Die()
    {
        
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.collectables.Remove(this.gameObject);
    }
}
