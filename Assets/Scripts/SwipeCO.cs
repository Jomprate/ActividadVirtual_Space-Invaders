using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwipeCO : MonoBehaviour {

    [SerializeField] TextMeshProUGUI specialCoolDownTXT;
    [SerializeField] bool CanShootSpecial = false;
    [SerializeField] float counterOfCoolDown;

    float timeToCountOfCoolDown = 60;

    private Vector3 startTouchPosition, endTouchPosition;

    Shoot shoot;

    private void Start ()
    {
        shoot = GameObject.FindGameObjectWithTag("BulletEmitter").GetComponent<Shoot>();
    }
	
	private void Update () {
		SwipeCheck ();

        #region Checker Of special shoot

        if (counterOfCoolDown > 0)
        {
            CanShootSpecial = false;
        }
        if (counterOfCoolDown <= 0)
        {
            
            CanShootSpecial = true;
        }

        if (CanShootSpecial)
        {
            specialCoolDownTXT.text = timeToCountOfCoolDown.ToString();
        }

        #endregion

        #region CoolDown Zone
        if (!CanShootSpecial)
        {
            if (counterOfCoolDown > 0)
            {
                CanShootSpecial = false;
                counterOfCoolDown -= Time.deltaTime;
                specialCoolDownTXT.text = counterOfCoolDown.ToString("##0.0");


                if (counterOfCoolDown <= 0)
                {
                    CanShootSpecial = true;
                }
            }
        }
        #endregion
    }

   
	private void SwipeCheck()
	{
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }    
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended)
        {
			endTouchPosition = Input.GetTouch (0).position;

            if (endTouchPosition.y > startTouchPosition.y && Vector2.Distance(endTouchPosition,startTouchPosition) > 400)
            {
                if (CanShootSpecial)
                {
                    shoot.MakeSpecialShoot();
                    counterOfCoolDown = timeToCountOfCoolDown;
                }
            }
        }
	}

	

}
