using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buylevel : MonoBehaviour
{
    public int LevelToBuy;
    public int LevelCost;
    public GameObject buy;
    // Start is called before the first frame update
    public void BuyLevel(){
        if (FindObjectOfType<GameManager>().MoneyButNotStatic >= LevelCost){
        FindObjectOfType<GameManager>().MoneyButNotStatic -= LevelCost;
        FindObjectOfType<GameManager>().MoneyUpdated();
        FindObjectOfType<LevelAllowed>().AddedLevel = LevelToBuy;
        FindObjectOfType<LevelAllowed>().BuyLevel();
        buy.SetActive(false);
        EventManager.OnUpdateUI();
        }
    }
    public void DontBuyLevel(){
        buy.SetActive(false);   
    }
}
