using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Text buttonText;
    public string levelName;
    
    // Start is called before the first frame update
    void Start(){
        buttonText.text = levelName;
    }
    public void OnClick (){
        Debug.Log(levelName);
        SceneManager.LoadScene(levelName);      
            
           

        }
        
        
        
        
    }
    

