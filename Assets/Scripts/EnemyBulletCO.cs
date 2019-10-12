using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCO : MonoBehaviour
{
    MainGoHealth mainGoHealth;
    public float speed;
    Rigidbody RB;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 velocityRB = RB.velocity;
        velocityRB.y = -speed;
        RB.velocity = velocityRB;
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ProtectionBase")
        {
            mainGoHealth = col.gameObject.GetComponent<MainGoHealth>();
            mainGoHealth.RemoveHealth(1);
            Destroy(gameObject);
        }

    }
}
