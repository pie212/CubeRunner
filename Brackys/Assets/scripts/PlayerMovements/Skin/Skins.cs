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
        if (FindObjectOfType<GameManager>().PLskin == SKIN){
             costtext.text = "Equipped";
        }
        else if (FindObjectOfType<SkinList>().SkinsListPUB.Contains(SKIN))
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
        UIupdate();
        if (FindObjectOfType<GameManager>().PLskin == SKIN){
             costtext.text = "Equipped";
        }
        else if (FindObjectOfType<SkinList>().SkinsListPUB.Contains(SKIN))
        {
            costtext.text = "Bought";
            
        }
    
        //if (Bought == true){
        //costtext.text = "bought";
        //}
        //if (Bought == false){
        //costtext.text = "Cost:" + Cost.ToString();
        //}
        

    }
    public void skinChange()
        {
        if (FindObjectOfType<SkinList>().SkinsListPUB.Contains(SKIN) == true)
        {
            costtext.text = "Equipped";
            UIupdate();
            FindObjectOfType<GameManager>().PLskin = SKIN;
            FindObjectOfType<GameManager>().StartSkin();
            
            EventManager.OnUpdateMoneyUI();
    
        }
        if (FindObjectOfType<SkinList>().SkinsListPUB.Contains(SKIN) == false)
        {
            if (FindObjectOfType<GameManager>().MoneyButNotStatic >= Cost)
            {
            FindObjectOfType<GameManager>().MoneyButNotStatic -= Cost;
            FindObjectOfType<GameManager>().MoneyUpdated();
            costtext.text = "bought";
            UIupdate();
            EventManager.OnUpdateMoneyUI();
            FindObjectOfType<SkinList>().TypeAdd = SKIN;
            FindObjectOfType<SkinList>().AddToSkin();
            }
        }
        
        
        

    
    
}       
}
