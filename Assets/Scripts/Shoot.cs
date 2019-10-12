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

    public void MakeShoot()
    {
        Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);
    }
    public void MakeSpecialShoot()
    {
        Instantiate(BulletType2, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation);
    }

}