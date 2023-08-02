using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class MoneyShowAmountText : MonoBehaviour
{
    //public GameManager GameManager;
    public Text Money;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Start()
    {
       Money.text = FindObjectOfType<GameManager>().MoneyButNotStatic.ToString("0"); 
    }
    private void OnEnable(){
        EventManager.UpdateMoneyUI += EventManagerOnUpdateMoneyUI;
        
    }
    private void EventManagerOnUpdateMoneyUI(){
        Money.text = FindObjectOfType<GameManager>().MoneyButNotStatic.ToString("0");
      
      
    }
    private void OnDisable(){
        EventManager.UpdateMoneyUI -= EventManagerOnUpdateMoneyUI;
    }
}
