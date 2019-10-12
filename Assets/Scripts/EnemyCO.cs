using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCO : MonoBehaviour
{
    private Transform enemyHolder;
    public float speedOfEnemies;
    public GameObject RotOBJ;
    public Transform RotTransform;

    readonly float fireRate =0.98f;
    readonly Shoot shoot;

    public GameObject Bullet;
    public RestartScene restartScene;

    void Start()
    {
        speedOfEnemies = 0.6f;

        RotTransform = RotOBJ.GetComponent<Transform>();
        InvokeRepeating("MoveEnemy", 0.1f, 0.2f);
        enemyHolder = GetComponent<Transform>();
    }
   
    
    public void MoveEnemy()
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
                Instantiate(Bullet, enemy.position, RotTransform.rotation);
                SoundControllerSC.PlaySound("PlayerFire");
            }

            if (enemy.position.y <= -2.2)
            {
                GameOver.playerIsDead = true;
                Time.timeScale = 0;
            }
        }

        if (enemyHolder.childCount <= 1)
        {
            restartScene.playerWon = true;
        }
    }


   
}
