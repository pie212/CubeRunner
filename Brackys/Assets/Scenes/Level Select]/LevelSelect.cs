

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour
{
    private Text buttonText;
    public int levelName;
    public GameObject buy;
    public int BuyCost;
    public buylevel buyscript;
    public GameObject lockscreen;
    
    public GameObject BuyScreen;
    private Animator cameraAnimator;
    EventSystem m_EventSystem;
    // UI UPDATE 
    
    // Start is called before the first frame update
    public void Start(){
        foreach (int item in ImportantVariables.LevelAllowed)
        {
            Debug.Log(item);
        }
        m_EventSystem = EventSystem.current;
        Debug.Log("Responese");
        if (ImportantVariables.LevelAllowed.Contains(levelName)){ 
            Debug.Log(ImportantVariables.LevelAllowed);
        lockscreen.SetActive(false);
        }
        EventManagerOnUpdateUI();
        
        //buttonText.text = levelName;          I DONT KNOW WHAT THE FUCK I DID, WHY IS THIS HERE. ?
    }
    public void OnClick (){
        
        //Debug.Log(levelName);
        Debug.Log("EEE");
        foreach( var x in ImportantVariables.LevelAllowed) {
        Debug.Log( x.ToString());
        }
        if (ImportantVariables.LevelAllowed.Contains(levelName)){
            Debug.Log("bongaA?");
        SceneManager.LoadScene("Level "+ levelName.ToString());                

        }
        else{
            Debug.Log("bongaAd?");
            FindObjectOfType<Animator>().SetTrigger("Tobuy");
            buy.SetActive(true);
            m_EventSystem.SetSelectedGameObject(BuyScreen);
            buyscript.LevelToBuy = levelName;
            buyscript.LevelCost  = BuyCost;
        }
        
        
        
        
    
    
}
    private void OnEnable(){
        EventManager.UpdateUI += EventManagerOnUpdateUI;
    }
    private void EventManagerOnUpdateUI(){
      Debug.Log("damnmnn");
      if (ImportantVariables.LevelAllowed.Contains(levelName)){            //lock screen is the lock icon
      if(lockscreen != null){
      lockscreen.SetActive(false);
      }
      }
    }
    private void OnDisable(){
        EventManager.UpdateUI -= EventManagerOnUpdateUI;
    }
}
