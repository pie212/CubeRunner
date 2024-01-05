using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelsSceneManager : MonoBehaviour
{
    EventSystem m_EventSystem;
    public Animator _anim;

    public GameObject BasicUI;
    public GameObject BasicSelected;

    public GameObject ArchUI;
    public GameObject ArchLeftbutton;
    public GameObject ArchRightbutton;
    
    // Start is called before the first frame update
    public void Start(){
        m_EventSystem = EventSystem.current;
    }
    public void ToMenu(){
        Invoke("ToMenu2", 2.0f);
        _anim.SetTrigger("back");
    }
    public void ToMenu2(){
        SceneManager.LoadSceneAsync("Menu");
    }
    public void ToBasic(){             // from basic to arches
        _anim.SetTrigger("Move left");
        BasicUI.SetActive(true);
        ArchUI.SetActive(false);
        m_EventSystem.SetSelectedGameObject(BasicSelected);

    }
    public void ToArchRight(){             // from basic to arches
        _anim.SetTrigger("Move right");
        BasicUI.SetActive(false);
        ArchUI.SetActive(true);
        m_EventSystem.SetSelectedGameObject(ArchLeftbutton);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
