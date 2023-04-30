using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour
{
    [SerializeField] private BoxCollider2D myCollider;
    [SerializeField] private GameObject spawnable;
    [SerializeField] private float maxTimeBetweenSpawns;
    [SerializeField] private float minTimeBetweenSpawns;
    private float timeTilNextSpawn;

    void OnEnable()
    {
        timeTilNextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        timeTilNextSpawn -= Time.deltaTime;
        if(timeTilNextSpawn <= 0)
        {
            timeTilNextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            SpawnObject(spawnable);
        }
    }

    void SpawnObject(GameObject toSpawn)
    {
        Vector3 point = RandomPointInBounds(myCollider.bounds);
        GameObject obj = Instantiate(toSpawn, point, Quaternion.identity);
        obj.transform.parent = this.transform;
    }

    public Vector3 RandomPointInBounds(Bounds bounds)
    {

        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            this.transform.position.z);
    }
}
