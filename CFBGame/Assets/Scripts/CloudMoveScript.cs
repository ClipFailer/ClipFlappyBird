using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    public float speed;
    private float deadZone = -67.3f;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x <= deadZone)
        {
            Destroy(gameObject);
        }

        transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
