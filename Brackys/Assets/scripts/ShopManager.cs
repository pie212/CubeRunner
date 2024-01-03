using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public GameObject Skins;
    public GameObject options;
    public GameObject Abilites;
    public GameObject SelectedSkinButton;
    public GameObject SelectedAbilityButton;
    public GameObject SelectedOptionButton;

    public Animator _anim;
    EventSystem m_EventSystem;
    
    // Start is called before the first frame update 
    void OnEnable()
    {
        m_EventSystem = EventSystem.current;           // this script is to go from main shop --> to abilites or skins
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toAbility(){
        _anim.SetTrigger("start");
        Invoke("toAbility2", 1);
        
    }
    void toAbility2(){
        
            Skins.SetActive(false);
            Abilites.SetActive(true);
            options.SetActive(false);
            m_EventSystem.SetSelectedGameObject(SelectedAbilityButton);
    }

    public void toSkins(){
        _anim.SetTrigger("start");
        Invoke("toSkins2", 1);
        
    }
    void toSkins2(){
            Skins.SetActive(true);
            Abilites.SetActive(false);
            options.SetActive(false);
            m_EventSystem.SetSelectedGameObject(SelectedSkinButton);
    }

    public void toMenu(){
        _anim.SetTrigger("start");
        Invoke("toMenu2", 1);
        
    }
    void toMenu2(){
            Skins.SetActive(false);
            Abilites.SetActive(false);
            options.SetActive(true);
            m_EventSystem.SetSelectedGameObject(SelectedOptionButton);
    }
}
