using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public string targetTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            Destroy(other.gameObject,0.02f);
        }
        Destroy(other.gameObject, 0.02F);
    }


}
