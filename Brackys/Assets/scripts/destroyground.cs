using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyground : MonoBehaviour
{
    public GameObject ground;
    public bool reverse;
    void OnTriggerEnter(Collider other)   
    {
        if (other.tag == "Player")
        {
          //FindObjectOfType<PLayerMovement>().jump = true;
          FindObjectOfType<PLayerMovement>().forwardForce += 300;
          
        
        } 

    }
    void OnTriggerExit(Collider other)   
    {
        if (other.tag == "Player")
        {
          
            Destroy(ground);
          
         
        
        }

    }
}
