using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverse : MonoBehaviour
{
    private PLayerMovement movement;
    public Animator animation;
    // Start is called before the first frame update
    // Start is called before the first frame update

    void Start(){
        movement = FindObjectOfType<PLayerMovement>();
    }
    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
        Debug.Log("Gravity Reversed");
        movement.rb.useGravity = false;
        movement.gravity = 1;   
        animation.SetBool("CamReturn", false);
        animation.SetBool("CamReverseGravity", true);
        
        }
        
    }
}
