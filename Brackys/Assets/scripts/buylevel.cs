
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
    public GameObject Level8;
    public GameObject Level9;
    public GameObject Level10;

    public GameObject Level11;
    public GameObject Level12;
    public GameObject Level13;
    public GameObject Level14;
    public GameObject Level15;
    public GameObject Level16;
    public GameObject Level17;
    public GameObject Level18;
    public GameObject Level19;
    public GameObject Level20;

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
        if (LevelToBuy == 8){
            m_EventSystem.SetSelectedGameObject(Level5);
        }
        if (LevelToBuy == 9){
            m_EventSystem.SetSelectedGameObject(Level6);
        }
        if (LevelToBuy == 10){
            m_EventSystem.SetSelectedGameObject(Level7);
        }




        if (LevelToBuy == 11){                              // 
            m_EventSystem.SetSelectedGameObject(Level11);
        }
        if (LevelToBuy == 12){
            m_EventSystem.SetSelectedGameObject(Level12);
        }
        if (LevelToBuy == 13){
            m_EventSystem.SetSelectedGameObject(Level13);
        }
        if (LevelToBuy == 14){
            m_EventSystem.SetSelectedGameObject(Level14);
        }
        if (LevelToBuy == 15){
            m_EventSystem.SetSelectedGameObject(Level15);
        }
        if (LevelToBuy == 16){
            m_EventSystem.SetSelectedGameObject(Level16);
        }
        if (LevelToBuy == 18){
            m_EventSystem.SetSelectedGameObject(Level17);
        }
        if (LevelToBuy == 18){
            m_EventSystem.SetSelectedGameObject(Level18);
        }
        if (LevelToBuy == 19){
            m_EventSystem.SetSelectedGameObject(Level19);
        }
        if (LevelToBuy == 20){
            m_EventSystem.SetSelectedGameObject(Level20);
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
