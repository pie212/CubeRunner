using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buylevel : MonoBehaviour
{
    public int LevelToBuy;
    public int LevelCost;
    public GameObject buy;


    // eventmantager bullshit so when returning from buy screen it goes back to sellected level

    EventSystem m_EventSystem;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public GameObject Level5;
    public GameObject Level6;
    public GameObject Level7;


    public void Start(){
        m_EventSystem = EventSystem.current;
    }
    // Start is called before the first frame update
    public void BuyLevel(){
        if (ImportantVariables.Money >= LevelCost){
        ImportantVariables.Money -= LevelCost;

        FindObjectOfType<LevelAllowed>().AddedLevel = LevelToBuy;
        FindObjectOfType<LevelAllowed>().BuyLevel();
        /// Event Manager logic

        if (LevelToBuy == 1){
            m_EventSystem.SetSelectedGameObject(Level1);
        }
        if (LevelToBuy == 2){
            m_EventSystem.SetSelectedGameObject(Level2);
        }
        if (LevelToBuy == 3){
            m_EventSystem.SetSelectedGameObject(Level3);
        }
        if (LevelToBuy == 4){
            m_EventSystem.SetSelectedGameObject(Level4);
        }
        if (LevelToBuy == 5){
            m_EventSystem.SetSelectedGameObject(Level5);
        }
        if (LevelToBuy == 6){
            m_EventSystem.SetSelectedGameObject(Level6);
        }
        if (LevelToBuy == 7){
            m_EventSystem.SetSelectedGameObject(Level7);
        }




        buy.SetActive(false);
        EventManager.OnUpdateUI();





        }
    }
    public void DontBuyLevel(){
         /// Event Manager logic

        if (LevelToBuy == 1){
            m_EventSystem.SetSelectedGameObject(Level1);
        }
        if (LevelToBuy == 2){
            m_EventSystem.SetSelectedGameObject(Level2);
        }
        if (LevelToBuy == 3){
            m_EventSystem.SetSelectedGameObject(Level3);
        }
        if (LevelToBuy == 4){
            m_EventSystem.SetSelectedGameObject(Level4);
        }
        if (LevelToBuy == 5){
            m_EventSystem.SetSelectedGameObject(Level5);
        }
        if (LevelToBuy == 6){
            m_EventSystem.SetSelectedGameObject(Level6);
        }
        if (LevelToBuy == 7){
            m_EventSystem.SetSelectedGameObject(Level7);
        }
        buy.SetActive(false); 

    }
}
