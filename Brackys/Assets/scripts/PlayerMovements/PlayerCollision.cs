
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PLayerMovement movement;

    void OnCollisionEnter (Collision collisionInfo) 
    {
        
        if (collisionInfo.collider.tag == "Obstacle"){
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        //if (collisionInfo.collider.tag == "Jumper"){
          //  Debug.Log("EEEEHT");
            //movement.rb.AddForce(0,20 * Time.deltaTime,0,ForceMode.VelocityChange);


        //}
            
    }
        

    
    
}
