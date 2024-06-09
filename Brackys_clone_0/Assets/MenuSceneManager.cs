using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class MenuSceneManager : MonoBehaviour
{
    public Animator _anim;
    
    
    public GameObject Credits;
    public GameObject Stats;
    public GameObject Menu;
    public GameObject Settings;
    EventSystem m_EventSystem;
    public GameObject MenuTextSelect;
    public GameObject SettingsTextSelect;
    public GameObject CreditsTextSelect;
    public GameObject StatsTextSelect;
    
    
    // Start is called before the first frame update
    public void Start(){
        m_EventSystem = EventSystem.current;
    }
    public void ToShop(){
        _anim.SetTrigger("ToShop");
        Invoke("ToShop2", 2f);
    }
    public void ToShop2(){
        SceneManager.LoadSceneAsync("Shop");
    }

    public void ToLevels(){
        _anim.SetTrigger("ToShop");     // we can reuse the animation since it goes down anyway
        Invoke("ToLevels2", 2f);
    }
    public void ToLevels2(){
        SceneManager.LoadSceneAsync("Levels");
    }
    // public void ToLevels(){
    //     SceneManager.LoadScene("LevelSelect");
    // }
    public void ToSettings(){
        _anim.SetTrigger("ToSettings");
        Settings.SetActive(true);
        Menu.SetActive(false);
        m_EventSystem.SetSelectedGameObject(SettingsTextSelect);

    }
    public void ToStats(){
        _anim.SetTrigger("ToStats");
        Menu.SetActive(false);
        Stats.SetActive(true);
        m_EventSystem.SetSelectedGameObject(StatsTextSelect);
        
        

    }

    public void ToCredits(){
        _anim.SetTrigger("ToCredits");
        Menu.SetActive(false);
        Credits.SetActive(true);
        m_EventSystem.SetSelectedGameObject(CreditsTextSelect);
        
        

    }
    public void Back(){
        
        _anim.SetTrigger("Return");
        
        Invoke("Back2", 1.5f);
    }
    public void Back2(){
        Menu.SetActive(true);
        Credits.SetActive(false);
        Stats.SetActive(false);
        Settings.SetActive(false);
        
        m_EventSystem.SetSelectedGameObject(MenuTextSelect);

    }
    
}
