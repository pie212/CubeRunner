
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
    
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject pauseLevelUI;
    public static float level = 0;
    private SuperHard SuperHard;
    public static int money = 0;
    public int MoneyButNotStatic;
    public int PowerUpType = 0;
    public PLayerMovement player;
    public GameObject itemsButton;         //button for controls       the first one to be selected for the pause ui 
    EventSystem m_EventSystem;              // current event system


    /// SKINS
    public int PLskin;
    public static int STATSkin;
    

    // PERKS
    public static int PerkMoney = 1;
    public int PerkMoneyCarrier;
    public void perkMoney(){
        PerkMoney += 1;
        PerkMoneyCarrier = PerkMoney;
        Debug.Log(PerkMoney);
        Debug.Log(PerkMoneyCarrier);
    }
    public void StartSkin(){
        STATSkin = PLskin;
        
    }
    void Awake(){
        PLskin = STATSkin;             // Sets the  carrier fo the static skin to the static skin which can be carried over into the other variable or script
        PerkMoneyCarrier = PerkMoney;    // Sets the carrier for the static PerkMoney variabel to the static one so the value of the static one can be carried into another script

    }
    void Start(){
        Debug.Log("ee");
        MoneyButNotStatic = money;
        m_EventSystem = EventSystem.current;          // sets the EventSystems
        
    }
    
    public void PauseGame(){
        pauseLevelUI.SetActive(true);
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
    level = SceneManager.GetActiveScene().buildIndex;
    //Debug.Log(level);
    


    }
    
    
    public void MoneyUpdated(){
        money = MoneyButNotStatic;


    }
    
    
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!!");
            Invoke("Restart", restartDelay);
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

