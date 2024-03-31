using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloudsScript : MonoBehaviour
{
    public GameObject spawnObject;

    private float timer;
    public float spawnRate = 2;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y, 1), transform.rotation);
    }
}
