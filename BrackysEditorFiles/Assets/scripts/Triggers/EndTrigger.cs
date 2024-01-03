using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private PLayerMovement movement;
    private GameManager GameManager;
    public LevelAllowed levele;
    public int NextLevel;
    
    
    
    void Start(){
        movement = FindObjectOfType<PLayerMovement>();
        GameManager = FindObjectOfType<GameManager>();
        levele = FindObjectOfType<LevelAllowed>();

    }
    
    
    void OnTriggerEnter(Collider other)   
    {
        if (other.tag == "Player")
        {
        movement.rb.constraints = RigidbodyConstraints.FreezePosition;
       
        FindObjectOfType<LevelAllowed>().AddedLevel = NextLevel;
        FindObjectOfType<LevelAllowed>().AddLevel();
        GameManager.CompleteLevel();    
        Debug.Log("HIT");
        }

    }
}
