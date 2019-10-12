using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerCO : MonoBehaviour
{
    Rigidbody rb;
    float direction_X;
    readonly float movementSpeed = 20f;
    Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = new Vector3(0, transform.position.y);
    }

    void Update()
    {
        direction_X = Input.acceleration.x * movementSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.9f, 8.9f),startPos.y , 0);
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(direction_X, 0f, 0f);
    }

}
