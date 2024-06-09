using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SuperHard : MonoBehaviour
{
    public Text buttonText;
    float used = 0f;
    public static bool superhard = false;
    // Start is called before the first frame update
    public void OnClick (){
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(superhard);
        used = 0f;
        if (superhard == true){
            buttonText.text = "Enable Superhard";
            UnityEngine.Debug.Log("SuperHard OFF");
            superhard = false;
            used = 1f;

        }
        if (superhard == false){
            if(used == 0)
            {
                buttonText.text = "Disable Superhard";
                UnityEngine.Debug.Log("SuperHard ON"); // checks if its actually working
                superhard = true;
            }
           

        }
        
        
        
        
    }
    
}
