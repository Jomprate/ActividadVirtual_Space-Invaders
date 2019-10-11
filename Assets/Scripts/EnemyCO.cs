using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCO : MonoBehaviour
{
    private Transform enemyHolder;
    public float speedOfEnemies;
    public GameObject RotOBJ;
    public Transform RotTransform;

    public int childs;

    float fireRate =0.98f;
    Shoot shoot;
    LinesCreator linesCreator;

    //public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force;


    // Start is called before the first frame update
    void Start()
    {
        speedOfEnemies = 0.6f;
        //shoot = GameObject.FindGameObjectWithTag("EnemyBulletEmitter").GetComponent<Shoot>();
        RotTransform = RotOBJ.GetComponent<Transform>();
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
        linesCreator = GameObject.FindGameObjectWithTag("LinesCreator").GetComponent<LinesCreator>();
    }
    void Update()
    {
        //shoot = GameObject.FindGameObjectWithTag("EnemyBulletEmitter").GetComponent<Shoot>();
        //if (enemyHolder.childCount >= 0)
        //{
        //    childs = enemyHolder.childCount;
        //    if (childs <= 0)
        //    {
        //        linesCreator.InstantiateLine();
        //    }
        //}
        
    }
    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speedOfEnemies;
        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -10.5f || enemy.position.x > 10.5f)
            {
                speedOfEnemies = -speedOfEnemies;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }
            float randomN = Random.Range(0.0f,1.0f);
            if (randomN > fireRate)
            {
                //******************************
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, enemy.position, RotTransform.rotation) as GameObject;//enemy.rotation) as GameObject;


                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(RotTransform.forward * Bullet_Forward_Force);


                //*****************************
            }

            if (enemy.position.y <= -2.2)
            {
                GameOver.playerIsDead = true;
                Time.timeScale = 0;
            }
        }
        

        //if (enemyHolder.childCount == 1 || enemyHolder.position.y < -1)
        //{
        //    CancelInvoke();
        //    InvokeRepeating("MoveEnemy", 0.1f, 0.25f);

        //}
        if (enemyHolder.childCount == 0)
        {
            //win
        }
    }
   
}
