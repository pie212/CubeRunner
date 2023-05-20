using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    
    public Animator animation;
    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
        Debug.Log("Camera2D");
          
        animation.SetBool("Cam2D", true);
        }
        
    }
}
