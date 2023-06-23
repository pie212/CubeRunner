using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    public void Levelrestart(){
        FindObjectOfType<Infinteplacerob>().ResetCord();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
