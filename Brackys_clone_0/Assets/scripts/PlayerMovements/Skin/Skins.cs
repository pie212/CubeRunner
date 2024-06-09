using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    
    public int SKIN;
    //public int SkinButton;
    public int Cost;
    private static bool Bought = false;
    private Text costtext;
    private string fulltext;



    void UIupdate(){
        if (ImportantVariables.skin == SKIN){
             costtext.text = "Equipped";
        }
        else if (ImportantVariables.SkinsList.Contains(SKIN) == true)
        {
            costtext.text = "Bought";
            
        }
        else
        {
            costtext.text = "Cost:" + Cost.ToString();
        }


    }
    
    // Start is called before the first frame update
    void Start(){
        costtext = GetComponentInChildren<Text>();
        Invoke("UIupdate", 0.1F);
        //if (FindObjectOfType<GameManager>().PLskin == SKIN){
             //costtext.text = "Equipped";
        ////}
       // else if (FindObjectOfType<SkinList>().SkinsListPUB.Contains(SKIN))
       // {
       //     costtext.text = "Bought";
            
      //  }
    
        //if (Bought == true){
        //costtext.text = "bought";
        //}
        //if (Bought == false){
        //costtext.text = "Cost:" + Cost.ToString();
        //}
        

    }
    public void skinChange()
        {
        if (ImportantVariables.SkinsList.Contains(SKIN) == true)
        {
            costtext.text = "Equipped";
            ImportantVariables.skin = SKIN;
            EventManager.OnUpdateShopUI();
            
            EventManager.OnUpdateMoneyUI();
    
        }
        if (ImportantVariables.SkinsList.Contains(SKIN) == false)
        {
            if (ImportantVariables.Money >= Cost)
            {
            ImportantVariables.Money -= Cost;
            
            costtext.text = "bought";
            EventManager.OnUpdateMoneyUI();
            //EventManager.OnUpdateShopUI();
            // FindObjectOfType<SkinList>().TypeAdd = SKIN;
            // FindObjectOfType<SkinList>().AddToSkin();
            ImportantVariables.SkinsList.Add(SKIN);
            }
        }
        
        
        

    
    
        }      

    private void OnEnable()
    {
        EventManager.UpdateShopUI += EventManagerOnUpdateShopUI;
        
    }
    private void EventManagerOnUpdateShopUI()
    {
        UIupdate();
      
      
    }
    private void OnDisable()
    {
        EventManager.UpdateShopUI -= EventManagerOnUpdateShopUI;

    }
}
