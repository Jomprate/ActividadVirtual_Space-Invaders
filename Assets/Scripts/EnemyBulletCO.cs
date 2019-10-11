using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCO : MonoBehaviour
{

    MainGoHealth mainGoHealth;

    Rigidbody RB;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (RB.velocity.magnitude < 1F)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ProtectionBase")
        {
            mainGoHealth = collision.gameObject.GetComponent<MainGoHealth>();
            mainGoHealth.RemoveHealth(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            mainGoHealth = collision.gameObject.GetComponent<MainGoHealth>();
            mainGoHealth.RemoveHealth(1);
            Destroy(gameObject);
        }

    }
}
