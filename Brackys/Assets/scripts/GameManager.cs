
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
    
{
    [HideInInspector]
    public bool gameHasEnded = false;
    [HideInInspector]
    public bool gameIsPaused = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject pauseLevelUI;
    public GameObject DeathUI;
    public static float level = 0;
    private SuperHard SuperHard;
    public int PowerUpType = 0;
    public PLayerMovement player;
    public GameObject itemsButton;         //button for controls       the first one to be selected for the pause ui 
    public GameObject itemsButtonDeath;
    EventSystem m_EventSystem;              // current event system


    
    

    // PERKS
    


    // Generation for endless levels

    public int Type = 1;

    
    
    
    
    
    void Start(){
        Debug.Log("ee");
        m_EventSystem = EventSystem.current;          // sets the EventSystems
        
    }
    
    public void PauseGame(){
        pauseLevelUI.SetActive(true);
        gameIsPaused = true;
    }
        
    
    public void CompleteLevel ()
    {
        player.jumpCON.Disable();      //allows input again
        player.move.Disable();
        player.powerup.Disable();
        player.menu.Disable();
        player.pitch.Disable();
        player.yaw.Disable();
        m_EventSystem.SetSelectedGameObject(itemsButton);  // sets the new FirstSelected to the menu
    //Debug.Log(SceneManager.GetActiveScene().buildIndex);
    completeLevelUI.SetActive(true);
    //level = SceneManager.GetActiveScene().buildIndex;
    //Debug.Log(level);
    


    }
    
    
    
    
    
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Achievementmanager.Deaths +=1;                                               // adds 1 for the achievement manager in deaths
            gameHasEnded = true;
            Debug.Log("Game Over!!");
            //FindObjectOfType<Infinteplacerob>().ResetCord();
            //Invoke("Restart", restartDelay);
            m_EventSystem.SetSelectedGameObject(itemsButtonDeath);
            DeathUI.SetActive(true);
        }

    }
    

        
    void Restart(){
            if (SuperHard.superhard == true){
                SceneManager.LoadScene(1);
            }
            else{
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
        


    }
    
}    

