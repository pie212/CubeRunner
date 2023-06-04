
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
    
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject pauseLevelUI;
    public static float level = 0;
    public SuperHard SuperHard;
    public static int money = 0;
    public int MoneyButNotStatic;
    public int PowerUpType = 0;

    void Start(){
        MoneyButNotStatic = money;
    }
    
    public void PauseGame(){
        pauseLevelUI.SetActive(true);
    }
        
    
    public void CompleteLevel ()
    {
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

