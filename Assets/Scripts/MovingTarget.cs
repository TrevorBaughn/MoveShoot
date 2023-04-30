using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetMover))]
public class MovingTarget : MonoBehaviour, IKillable
{
    private TargetMover mover;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    private float speed;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject bombPrefab;

    private float bombSpot;
    private bool rightSpawn;
    GameObject bomb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            GameObject coin = Instantiate(coinPrefab, this.transform.position, Quaternion.identity);

            coin.transform.parent = this.gameObject.transform.parent;

            IKillable ikillable;
            collision.gameObject.TryGetComponent(out ikillable);
            ikillable.Die();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //flip it if on the right
        if(this.gameObject.transform.position.x > 0)
        {
            this.gameObject.transform.Rotate(Vector3.up, 180);
            rightSpawn = true;
        }
        else
        {
            rightSpawn = false;
        }

        mover = this.GetComponent<TargetMover>();

        //get a random speed on start
        speed = Random.Range(minSpeed, maxSpeed);

        bombSpot = Random.Range(-14, 14);

        GameManager.instance.ais.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        mover.MoveForward(speed);
        if(bomb == null) {
            if (rightSpawn && gameObject.transform.position.x < bombSpot)
            {
                bomb = Instantiate(bombPrefab, this.transform.position, Quaternion.identity);
                bomb.transform.parent = this.gameObject.transform.parent;
            }
            else if (!rightSpawn && gameObject.transform.position.x > bombSpot)
            {
                bomb = Instantiate(bombPrefab, this.transform.position, Quaternion.identity);
                bomb.transform.parent = this.gameObject.transform.parent;
            }
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
