

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PowerupTypeUI powerUpTypeUI;       // to update the powerupui instead of using update
    private PLayerMovement movement;
    public bool has_collided = false;
    public static bool hasDied;

    void Start(){
            movement = GetComponent<PLayerMovement>();
        }
    void OnCollisionEnter (Collision collisionInfo) 
    {
        
        
        if (collisionInfo.collider.tag == "Obstacle" && has_collided == false) 
        {
            
            if (FindObjectOfType<GameManager>().PowerUpType != 2)
            {
                has_collided = true;
                hasDied = true;
                movement.enabled = false;
                ImportantVariables.PlayerDeaths += 1;
                FindObjectOfType<GameManager>().EndGame();
            }
            if (FindObjectOfType<GameManager>().PowerUpType == 2)
            {
                FindObjectOfType<GameManager>().PowerUpType = 0;
            }
            powerUpTypeUI = FindObjectOfType<PowerupTypeUI>();
        powerUpTypeUI.UpdateUI();
        }
        if (collisionInfo.collider.tag == "Spike" && has_collided == false)
        {

            if (FindObjectOfType<GameManager>().PowerUpType != 2)
            {
            has_collided = true;
            movement.enabled = false;
            Achievementmanager.DeathBySpike += 1;               // adds 1 to death by spike
            FindObjectOfType<GameManager>().EndGame();
            }
            if (FindObjectOfType<GameManager>().PowerUpType == 2)
            {
                FindObjectOfType<GameManager>().PowerUpType = 0;
            }
            powerUpTypeUI = FindObjectOfType<PowerupTypeUI>();
            powerUpTypeUI.UpdateUI();
        }
        if (collisionInfo.collider.tag == "CubeOBS" && has_collided == false)
        {
            if (FindObjectOfType<GameManager>().PowerUpType != 2)
            {
            has_collided = true;
            movement.enabled = false;
            Achievementmanager.DeathByCube += 1;               // adds 1 to death by cube
            FindObjectOfType<GameManager>().EndGame();
            }
            if (FindObjectOfType<GameManager>().PowerUpType == 2)
            {
                FindObjectOfType<GameManager>().PowerUpType = 0;
            }
            powerUpTypeUI = FindObjectOfType<PowerupTypeUI>();
            powerUpTypeUI.UpdateUI();

        }   

        //if (collisionInfo.collider.tag == "Jumper"){
          //  Debug.Log("EEEEHT");
            //movement.rb.AddForce(0,20 * Time.deltaTime,0,ForceMode.VelocityChange);


        //}
        
            
    }
        

    
    
}
