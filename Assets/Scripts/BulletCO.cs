using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCO : MonoBehaviour
{
    public bool Btype1 = false;
    public bool Btype2 = false;
    MainGoHealth mainGoHealth;
    Rigidbody RB;
    Collider ColliderOBJ;
    Collider collisionCol;
    bool counted = false;
    

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        ColliderOBJ = GetComponent<Collider>();
    }

    void Update()
    {
        
        #region Only One Type CHECKER
        if (Btype1)
        {
            Btype2 = false;
        }
        if (Btype2)
        {
            Btype1 = false;
        }
        if (!Btype1)
        {
            Btype2 = true;
        }
        if (!Btype2)
        {
            Btype1 = true;
        }
        #endregion

        if (RB.velocity.magnitude <0.5F)
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

        if (Btype1)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);

                addEnemyKilled();
                //ColliderOBJ.enabled = false;
                Destroy(gameObject);
            }
            //ColliderOBJ.enabled = false;
        }

        if (Btype2)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                //addScore
                Destroy(collision.gameObject);

                addEnemyKilled();
               


            }
        }
    }
    

    void OnTriggerEnter(Collider col)
    {
        //if (Btype1)
        //{
        //    if (col.tag == "Enemy")
        //    {
                               
        //        //addScore
        //        Destroy(col.gameObject);
        //        if (counted == false)
        //        {
                    
        //            ColliderOBJ.enabled = false;
        //            EnemyDeathCounter.enemyKilled += 1;
        //            counted = true;
        //        }
        //        Destroy(gameObject);

                
        //    }
        //}
        //if (Btype2)
        //{
        //    if (col.tag == "Enemy")
        //    {
        //        //addScore

        //        //if (counted == false)
        //        //{

        //        //    //ColliderOBJ.enabled = false;

        //        //    counted = true;
        //        //}
        //        addEnemyKilled();
        //        Destroy(col.gameObject);


        //    }
        //}

        

    }

    void addEnemyKilled()
    {
        EnemyDeathCounter.enemyKilled += 1;

    }
}
