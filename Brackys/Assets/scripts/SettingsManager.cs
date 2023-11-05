using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{
    public Slider SliderMobileControls;
    public Text SliderMobileControlsText;



    public Slider SliderMenuMusic;
    public Text SliderMenuMusicText;
    void Start()
    {
        SliderMobileControlsText.text = ImportantVariables.MobileSensitivity.ToString("0.0");
        SliderMobileControls.value = ImportantVariables.MobileSensitivity;
        SliderMobileControls.onValueChanged.AddListener((a) => {
            ImportantVariables.MobileSensitivity = Mathf.Round(a * 10.0f) * 0.1f;
           SliderMobileControlsText.text = ImportantVariables.MobileSensitivity.ToString("0.0");
        });



        SliderMenuMusicText.text = ImportantVariables.MenuMusicVol.ToString("0.0");
        SliderMenuMusic.value = ImportantVariables.MenuMusicVol;
        SliderMenuMusic.onValueChanged.AddListener((b) => {
            ImportantVariables.MenuMusicVol = Mathf.Round(b * 10.0f) * 0.1f;
            FindObjectOfType<AudioSource>().volume = ImportantVariables.MenuMusicVol;
           SliderMenuMusicText.text = ImportantVariables.MenuMusicVol.ToString("0.0");
        });
        
        





    }
            

    // Update is called once per frame
   
}
