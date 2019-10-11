using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesCreator : MonoBehaviour
{
    Transform LastPosition;
    public GameObject EnemiesOBJ;
    public GameObject EToCreateOBJ;

    public Vector3 LastPosVect3 = new Vector3(-3.4f,4.6f,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LastPosVect3 = new Vector3(EnemiesOBJ.transform.position.x, EnemiesOBJ.transform.position.y+1.8f, 0);
    }

    public  void InstantiateLine()
    {
        
        Instantiate(EToCreateOBJ, LastPosVect3,EToCreateOBJ.transform.rotation);

    }


}
