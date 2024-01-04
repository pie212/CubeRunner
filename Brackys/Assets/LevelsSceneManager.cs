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
    public Gameobject ArchLeftbutton;
    public GameObject ArchRightbutton;
    
    // Start is called before the first frame update
    public void Start(){
        m_EventSystem = EventSystem.current;
    }
    public void ToArchRight(){             // from basic to arches
        BasicUI.SetActive(false);
        m_EventSystem.SetSelectedGameObject(ArchLeftbutton);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
