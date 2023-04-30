using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IKillable ikillable;
        collision.gameObject.TryGetComponent(out ikillable);

        if (ikillable != null) //if the colliding gameobject is ikillable
        {
            ikillable.Die();
        }
        else //otherwise just destroy the gameobject
        {
            Destroy(collision.gameObject);
        }
    }
}
