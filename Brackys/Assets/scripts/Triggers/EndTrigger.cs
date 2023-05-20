using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public PLayerMovement movement;
    public GameManager GameManager;
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
