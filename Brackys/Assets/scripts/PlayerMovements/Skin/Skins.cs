using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour
{
    public static int Skin = 0;
    public int SKIN;
    public int SkinButton;
    public int Cost;
    private bool Bought = false;
    // Start is called before the first frame update
    public void skinChange(){
        Skin = SkinButton;
        FindObjectOfType<GameManager>().MoneyButNotStatic -= Cost;
        FindObjectOfType<GameManager>().MoneyUpdated();
        bought = true;

    }
    void Start(){
        SKIN = Skin;

    }
}       
