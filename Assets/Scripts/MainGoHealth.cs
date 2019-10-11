using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGoHealth : MonoBehaviour
{
    [SerializeField]
    public float health = 1;


    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void RemoveHealth(float dmgAmount)
    {
        health -= dmgAmount;
    }
}
