using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyground : MonoBehaviour
{
    public GameObject ground;
     void OnTriggerEnter(Collider other)   
    {
        if (other.tag == "Player")
        {
          FindObjectOfType<PLayerMovement>().jump = true;
          Destroy(ground);
        
        } 

    }
    void OnTriggerExit(Collider other)   
    {
        if (other.tag == "Player")
        {
          FindObjectOfType<PLayerMovement>().jump = true;
          
        
        }

    }
}
