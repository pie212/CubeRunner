using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnToMenu(){
        SceneManager.LoadScene("Menu");

    }
}
