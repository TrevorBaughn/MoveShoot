using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObject : MonoBehaviour, IKillable
{
    [SerializeField] private int damage;

    void Start()
    {
        GameManager.instance.collectables.Add(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Responsibility>().current -= damage;
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
