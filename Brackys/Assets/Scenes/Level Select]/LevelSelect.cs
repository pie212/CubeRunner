using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Text buttonText;
    public int levelName;
    public GameObject buy;
    public int BuyCost;
    public buylevel buyscript;
    public GameObject lockscreen;

    // UI UPDATE 
    
    // Start is called before the first frame update
    public void Start(){
        if (FindObjectOfType<LevelAllowed>().AllowedLevels.Contains(levelName)){ 
            Debug.Log("huh?");
        lockscreen.SetActive(false);
        }
        
        //buttonText.text = levelName;          I DONT KNOW WHAT THE FUCK I DID, WHY IS THIS HERE. ?
    }
    public void OnClick (){
        //Debug.Log(levelName);
        Debug.Log("EEE");
        foreach( var x in FindObjectOfType<LevelAllowed>().AllowedLevels) {
        Debug.Log( x.ToString());
        if (FindObjectOfType<LevelAllowed>().AllowedLevels.Contains(levelName)){
        SceneManager.LoadScene("Level "+ levelName.ToString());                

        }
        else{
            buy.SetActive(true);
            buyscript.LevelToBuy = levelName;
            buyscript.LevelCost  = BuyCost;
        }
        
        
        
        
    }
    
}
    private void OnEnable(){
        EventManager.UpdateUI += EventManagerOnUpdateUI;
    }
    private void EventManagerOnUpdateUI(){
      if (FindObjectOfType<LevelAllowed>().AllowedLevels.Contains(levelName)){ 
      lockscreen.SetActive(false);
      }
    }
    private void OnDisable(){
        EventManager.UpdateUI -= EventManagerOnUpdateUI;
    }
}
