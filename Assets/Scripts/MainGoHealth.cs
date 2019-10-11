using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGoHealth : MonoBehaviour
{
    [SerializeField]
    public float health = 1;
    bool count = false;
    float counter = 1;
    float mTime;

    bool Execute = false;

    void Update()
    {
        if (health <= 0)
        {
            if (!Execute)
            {
                WhenDead();
                Execute = true;
            }
            Destroy(gameObject, 1);


        }
    }
    public void RemoveHealth(float dmgAmount)
    {
        health -= dmgAmount;
    }

    public void WhenDead()
    {
        SoundControllerSC.PlaySound("SpaceExplosion");

    }
}
