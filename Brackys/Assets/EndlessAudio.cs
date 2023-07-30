using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndlessAudio : MonoBehaviour
{

    private void Update()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        

        

        //if (sceneName == "Level Endless")
        //{
            //DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
            //Debug.Log("What the shit");
         //   Destroy(gameObject);
       // }
        
        if (FindObjectOfType<GameManager>().gameHasEnded == true){
            GetComponent<AudioSource>().Pause();
        }
        if (FindObjectOfType<GameManager>().gameIsPaused == true){
            GetComponent<AudioSource>().Pause();
        }
       
      
    }
   
}
