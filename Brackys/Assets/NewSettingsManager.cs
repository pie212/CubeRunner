using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewSettingsManager : MonoBehaviour
{
     public TextMeshPro MenuMusicVal;
     public TextMeshPro MobileSensitivityVal;
     public TextMeshPro ControllerVal;
    // Start is called before the first frame update
    

    // Update is called once per frame

    public void Start(){
        MenuMusicVal.text = (ImportantVariables.MenuMusicVol*10).ToString("0");
        MobileSensitivityVal.text = (ImportantVariables.MobileSensitivity*10).ToString("0");
        if (ImportantVariables.MouseVisible == false){ControllerVal.text = "ON";}
        else{ControllerVal.text = "OFF";}
    }
    public void MenuMusicUp(){
        if (ImportantVariables.MenuMusicVol < 1.0F){
            ImportantVariables.MenuMusicVol += 0.1F;
            MenuMusicVal.text = (ImportantVariables.MenuMusicVol*10).ToString("0");
        }

    }
    public void MenuMusicDown(){
        if (ImportantVariables.MenuMusicVol > 0){
            ImportantVariables.MenuMusicVol -= 0.1F;
            MenuMusicVal.text = (ImportantVariables.MenuMusicVol*10).ToString("0");
        }

    }

    public void MobileSensitivityUp(){
        if (ImportantVariables.MobileSensitivity < 1.0F){
            ImportantVariables.MobileSensitivity += 0.1F;
            MobileSensitivityVal.text = (ImportantVariables.MobileSensitivity*10).ToString("0");
        }

    }
    public void MobileSensitivityDown(){
        if (ImportantVariables.MobileSensitivity > 0){
            ImportantVariables.MobileSensitivity -= 0.1F;
            MobileSensitivityVal.text = (ImportantVariables.MobileSensitivity*10).ToString("0");
        }

    }
    public void Controller(){
        if (ImportantVariables.MouseVisible == true){
            ImportantVariables.MouseVisible = false;
            Cursor.visible = false;
            ControllerVal.text = "ON";
        }
        else{
            ImportantVariables.MouseVisible = true;
            Cursor.visible = true;
            ControllerVal.text = "OFF";
        }
    }
}
