using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopSceneManager : MonoBehaviour
{
    public Animator _anim;
    public Animator SkinsAnim;
    public Animator AbilityAnim;
    
    public GameObject Skins;
    public GameObject Abilitys;
    public GameObject Menu;
    EventSystem m_EventSystem;
    public GameObject SkinTextSelect;
    public GameObject AbilityTextSelect;
    public GameObject MenuTextSelect;

    public Image tooltip;
    // Start is called before the first frame update
    public void Start(){
        m_EventSystem = EventSystem.current;
    }
    public void ToSkin(){
        _anim.SetTrigger("ToSkin");
        Menu.SetActive(false);
        Skins.SetActive(true);
        m_EventSystem.SetSelectedGameObject(SkinTextSelect);

    }
    public void ToAbility(){
        _anim.SetTrigger("ToAbility");
        Menu.SetActive(false);
        Abilitys.SetActive(true);
        m_EventSystem.SetSelectedGameObject(AbilityTextSelect);
        //fixes making tooltips active
        //please add future tooltips below
        tooltip.gameObject.SetActive(false);
        
        

    }
    public void Back(){
        SkinsAnim.SetTrigger("back");
        AbilityAnim.SetTrigger("back");
        _anim.SetTrigger("Return");
        Invoke("Back2", 1f);
    }
    public void Back2(){
        Menu.SetActive(true);
        Skins.SetActive(false);
        Abilitys.SetActive(false);
        m_EventSystem.SetSelectedGameObject(MenuTextSelect);

    }
    public void ToMenu(){
        _anim.SetTrigger("ToMenu");
        Invoke("ToMenu2", 2f);
    }
    public void ToMenu2(){
        SceneManager.LoadScene("Menu");
    }
    
}
