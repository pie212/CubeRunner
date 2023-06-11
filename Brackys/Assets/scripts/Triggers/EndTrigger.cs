using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private PLayerMovement movement;
    private GameManager GameManager;
    
    
    void Start(){
        movement = FindObjectOfType<PLayerMovement>();
        GameManager = FindObjectOfType<GameManager>();
    }
    
    
    void OnTriggerEnter(Collider other)   
    {
        if (other.tag == "Player")
        {
        movement.rb.constraints = RigidbodyConstraints.FreezePosition;
        GameManager.CompleteLevel();    
        Debug.Log("HIT");
        }

    }
}
