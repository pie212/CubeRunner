using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadEndless : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick(){
        SceneManager.LoadScene("Level Endless"); 
    }
    public void PressStart(){
        SceneManager.LoadScene("PressStart"); 
    }
}
