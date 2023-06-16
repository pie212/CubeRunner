using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Text buttonText;
    public int levelName;
    
    // Start is called before the first frame update
    void Start(){
        //buttonText.text = levelName;          I DONT KNOW WHAT THE FUCK I DID, WHY IS THIS HERE. ?
    }
    public void OnClick (){
        //Debug.Log(levelName);
        Debug.Log("EEE");
        foreach( var x in FindObjectOfType<LevelAllowed>().AllowedLevels) {
        Debug.Log( x.ToString());
        if (FindObjectOfType<LevelAllowed>().AllowedLevels.Contains(levelName))
        SceneManager.LoadScene("Level "+ levelName.ToString());      
            
           

        }
        
        
        
        
    }
    
}
