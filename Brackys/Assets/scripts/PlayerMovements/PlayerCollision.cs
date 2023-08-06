

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PLayerMovement movement;

    void Start(){
            movement = GetComponent<PLayerMovement>();
        }
    void OnCollisionEnter (Collision collisionInfo) 
    {
        
        
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (FindObjectOfType<GameManager>().PowerUpType != 2)
            {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            }
            if (FindObjectOfType<GameManager>().PowerUpType == 2)
            {
                FindObjectOfType<GameManager>().PowerUpType = 0;
            }
        }
        if (collisionInfo.collider.tag == "Spike")
        {
            if (FindObjectOfType<GameManager>().PowerUpType != 2)
            {
            movement.enabled = false;
            Achievementmanager.DeathBySpike += 1;               // adds 1 to death by spike
            FindObjectOfType<GameManager>().EndGame();
            }
            if (FindObjectOfType<GameManager>().PowerUpType == 2)
            {
                FindObjectOfType<GameManager>().PowerUpType = 0;
            }
        }
        if (collisionInfo.collider.tag == "CubeOBS")
        {
            if (FindObjectOfType<GameManager>().PowerUpType != 2)
            {
            movement.enabled = false;
            Achievementmanager.DeathByCube += 1;               // adds 1 to death by cube
            FindObjectOfType<GameManager>().EndGame();
            }
            if (FindObjectOfType<GameManager>().PowerUpType == 2)
            {
                FindObjectOfType<GameManager>().PowerUpType = 0;
            }

        }
        //if (collisionInfo.collider.tag == "Jumper"){
          //  Debug.Log("EEEEHT");
            //movement.rb.AddForce(0,20 * Time.deltaTime,0,ForceMode.VelocityChange);


        //}
        
            
    }
        

    
    
}
