
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class EnableSuperHard : MonoBehaviour
{
    public Text buttonText;
    
    public static bool superhard = false;
    // Start is called before the first frame update
    public void TextChange (){
        if (superhard == true){
            buttonText.text = "Disable Superhard";
            UnityEngine.Debug.Log("SuperHard OFF");
            superhard = false;

        }
        if (superhard == false){
            buttonText.text = "Enable Superhard";
            UnityEngine.Debug.Log("SuperHard ON"); // checks if its actually working
            superhard = true;

        }
        
        
        
        
    }
    
}

