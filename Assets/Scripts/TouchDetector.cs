using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchDetector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coolDownTXT;
    [SerializeField] TextMeshProUGUI EnemyKilledTXT;

    bool canTouch = false;
    float counterOfShoots;
    float timeToCountOfShoots = 3;

    [SerializeField]float counterOfCoolDown;
    float timeToCountOfCoolDown = 30; 

    bool CanShootB1;
    [SerializeField]bool shootB1Active;

    Shoot shoot;

    void Start()
    {
        shoot = GameObject.FindGameObjectWithTag("BulletEmitter").GetComponent<Shoot>();

    }

    void Update()
    {
        EnemyKilledTXT.text = EnemyDeathCounter.enemyKilled.ToString();

        #region Call the touch functions
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                OneFingerTouch();
            }
            
        }

        if (Input.touchCount == 3)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ThreeFingerTouch(); 
            }
            
        }
        #endregion

        #region Checker Of multiple shoots

        if (counterOfCoolDown > 0)
        {
            CanShootB1 = false;
        }
        if (counterOfCoolDown <= 0)
        {
            CanShootB1 = true;
        }

        #endregion

        #region Burst Shoot
        if (CanShootB1 == true)
        {
            coolDownTXT.text = 30.ToString();
        }

        if (shootB1Active)
        {
            CanShootB1 = false;

            if (counterOfShoots > 0)
            {
                shoot.MakeShoot();
                Debug.Log("DISPARO OTRA");
                counterOfShoots -= Time.deltaTime;
                
                if (counterOfShoots <= 0)
                {
                    shootB1Active = false;
                }
            }
        }

        #endregion
        
        #region CoolDown Zone
        if (!CanShootB1)
        {
            if (counterOfCoolDown > 0)
            {
                CanShootB1 = false;

                counterOfCoolDown -= Time.deltaTime;
                coolDownTXT.text = counterOfCoolDown.ToString("##0");
                if (counterOfCoolDown <= 0)
                {
                    CanShootB1 = true;
                }
            }
        }
        #endregion



    }
    


    void OneFingerTouch()
    {
        Debug.Log("Un solo Dedo");
        //dispara una sola bala
        shoot.MakeShoot();

    }
    void TwoFingerTouch()
    {
        Debug.Log("Dos Dedos");

    }
    void ThreeFingerTouch()
    {
        Debug.Log("Tres Dedos");
        if (CanShootB1)
        {
            shootB1Active = true;
            counterOfShoots = timeToCountOfShoots;
            counterOfCoolDown = timeToCountOfCoolDown;
        }
        //dispara rafaga de balas


    }
}
