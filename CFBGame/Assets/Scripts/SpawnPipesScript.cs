using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject spawnObject;
    public float spawnRate = 2;
    private float timer = 0;

    private float lowestPos = -7.2f;
    private float highestPos = -0.99f;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        Debug.Log("Pipe spawned.");
        Instantiate(spawnObject, new Vector3(transform.position.x, Random.Range(lowestPos, highestPos), 0), transform.rotation);
    }
}
