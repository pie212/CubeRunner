using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MobileSens : MonoBehaviour
{
    public Slider _slider;
    public Text Sltext;
    void Start()
    {
        Sltext.text = ImportantVariables.MobileSensitivity.ToString("0.0");
        _slider.value = ImportantVariables.MobileSensitivity;
        _slider.onValueChanged.AddListener((v) => {
            ImportantVariables.MobileSensitivity = Mathf.Round(v * 10.0f) * 0.1f;
           Sltext.text = ImportantVariables.MobileSensitivity.ToString("0.0");
        });
    }
            

    // Update is called once per frame
    void Update()
    {
        
    }
}
