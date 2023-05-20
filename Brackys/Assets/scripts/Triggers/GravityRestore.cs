using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRestore : MonoBehaviour
{
    // Start is called before the first frame update
    public PLayerMovement movement;
    public Animator animation;
    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
        Debug.Log("Gravity Restored");
        movement.rb.useGravity = true;
        movement.gravity = 0;   
        animation.SetBool("CamReturn", true);
        animation.SetBool("CamReverseGravity", false);
        }
    }
}
