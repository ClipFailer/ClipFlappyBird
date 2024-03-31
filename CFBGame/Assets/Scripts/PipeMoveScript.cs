using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    private float deadZone = -18.37f;

    void Update()
    {
        if (transform.position.x <= deadZone)
        {
            Debug.Log("Pipe deleted.");
            Destroy(gameObject);
        }

        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
}
