using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet_Emitter;     
    public GameObject Bullet;
    public GameObject BulletType2;

    public float Bullet_Forward_Force;

    public float enemyCounter;
    private bool canShoot = true;

    void Start()
    {

    }

    void Update()
    {
     

        
    }

    public void MakeShoot()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;


        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);


    }
    public void MakeSpecialShoot()
    {
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(BulletType2, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;


        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);


    }

}