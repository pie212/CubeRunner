using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public PLayerMovement movement;
    public float UpwardForce = 1000f;
    // Start is called before the first frame update
    void OnTriggerEnter(){
        Debug.Log("Jump script works");
        movement.rb.AddForce(0,UpwardForce*Time.deltaTime,0, ForceMode.VelocityChange);




    }
}
