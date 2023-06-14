using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public static int Skin = 0;
    public int SKIN;
    public int SkinButton;
    public int Cost;
    private static bool Bought = false;
    private Text costtext;
    private string fulltext;
    // Start is called before the first frame update
    public void skinChange(){
        if (Bought == false)
        {
        Skin = SkinButton;
        FindObjectOfType<GameManager>().MoneyButNotStatic -= Cost;
        FindObjectOfType<GameManager>().MoneyUpdated();
        Bought = true;
        costtext.text = "bought";
        
        }

    }
    void Start(){
        SKIN = Skin;
        costtext = GetComponentInChildren<Text>();
        if (Bought == true){
        costtext.text = "bought";
        }
        if (Bought == false){
        costtext.text = "Cost:" + Cost.ToString();
        }
        

    }
}       
