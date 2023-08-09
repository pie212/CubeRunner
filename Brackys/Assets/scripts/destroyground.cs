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
          FindObjectOfType<PLayerMovement>().jump = true;
          
        
        } 

    }
    void OnTriggerExit(Collider other)   
    {
        if (other.tag == "Player")
        {
          if (reverse == false){
            FindObjectOfType<PLayerMovement>().jump = false;
            Destroy(ground);
          }
          if (reverse == true){
            FindObjectOfType<PLayerMovement>().jump = false;
            Destroy(ground);
          }
        
        }

    }
}
