

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PLayerMovement movement;

    void OnCollisionEnter (Collision collisionInfo) 
    {
        
        if (collisionInfo.collider.tag == "Obstacle"){
            if (FindObjectOfType<GameManager>().PowerUpType != 2)
            {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            }
            if (FindObjectOfType<GameManager>().PowerUpType == 2){
                FindObjectOfType<GameManager>().PowerUpType = 0;
            }

        }
        //if (collisionInfo.collider.tag == "Jumper"){
          //  Debug.Log("EEEEHT");
            //movement.rb.AddForce(0,20 * Time.deltaTime,0,ForceMode.VelocityChange);


        //}
        if (collisionInfo.collider.tag == "TREE"){
            Debug.Log("TREE");
        }
            
    }
        

    
    
}
