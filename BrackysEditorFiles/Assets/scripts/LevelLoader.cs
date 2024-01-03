using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    public Animator TransitionShop;
    public float transitionTime = 1F;
    private string levelload = "";
    // Start is called before the first frame update
    public void StartGame(){
        //SceneManager.LoadScene("Level 1");
        levelload = "Level 1";
        StartAn();
    }
    public void LevelSelect(){
        //SceneManager.LoadScene("LevelSelect"); 
        levelload = "LevelSelect"; 
        StartAn();
    }
    public void Shop(){
        //SceneManager.LoadScene("Shop"); 
        levelload = "Shop2";
        StartAn();

    }
    public void LoadMenu(){
        //SceneManager.LoadScene("Shop"); 
        levelload = "Menu";
        StartAn();

    }
    public void LoadMenuFromShop(){
        //SceneManager.LoadScene("Shop"); 
        levelload = "Menu";
        StartAn2();

    }
    public void LoadStats(){
        //SceneManager.LoadScene("Shop"); 
        levelload = "Stats";
        StartAn();

    }

    public void LoadSettings(){
        //SceneManager.LoadScene("Shop"); 
        levelload = "Settings";
        StartAn();

    }

    public void StartAn(){
        StartCoroutine(LoadLevel());
    }
    public void StartAn2(){
        StartCoroutine(LoadLevel2());
    }


    IEnumerator LoadLevel(){
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelload); 

        
    }
    IEnumerator LoadLevel2(){
        TransitionShop.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelload); 

        
    }
}
