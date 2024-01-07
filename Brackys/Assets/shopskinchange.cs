
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class shopskinchange : MonoBehaviour
{
    
    public TextMeshPro moneyAbility;
    public TextMeshPro moneyShop;
    private MeshRenderer player;
    // public MeshFilter playerm;
    
    public List<Material> skins = new List<Material>();
    // public List<Mesh> meshes = new List<Mesh>();
    public int defaultSkin = 0;
    public Animator _anim;
    public List<int> costs = new List<int>();
    public int cost;         // cost of first item
    public TextMeshPro text;

    public bool CanPressed;         // quick bool to make sure the player cannot press the button while the animation is playing    
    // Start is called before the first frame update
    void Start()
    {
     

     CanPressed = true;
     cost = costs[defaultSkin];
     player = GetComponent<MeshRenderer>();
     player.material = skins[defaultSkin];
     skinChange();

    }

    // Update is called once per frame
    
    public void NextSkin()
    { 
        
        if (skins.Count > (defaultSkin +1 )){        // list comprehension
        CanPressed = false;
        _anim.SetTrigger("exit");
        Debug.Log("next");
        defaultSkin += 1;
        Invoke("skinChange", 0.5f);
        }
    }
    public void PreviousSkin(){
        if (0 < defaultSkin){
        _anim.SetTrigger("exit");
        defaultSkin -= 1;
        Invoke("skinChange", 0.5f);
        }

    }
    public void skinChange(){    // seprate function so we can use invoke for a slight delay
        
        player.material = skins[defaultSkin];
        // playerm.mesh  = meshes[defaultSkin];
        cost = costs[defaultSkin];
        if (ImportantVariables.skin == defaultSkin){
            text.text = "Equipped";
        }
        else if (ImportantVariables.SkinsList.Contains(defaultSkin) == true){
            text.text = "Bought";
        }
        else{
            text.text = "Cost: " + cost.ToString();
        }
        CanPressed = true;
        Debug.Log(CanPressed);
        moneyAbility.text = ImportantVariables.Money.ToString("0");
        moneyShop.text = ImportantVariables.Money.ToString("0");
        
    }
    public void BuySkin(){
        if (CanPressed == true){
            if (ImportantVariables.SkinsList.Contains(defaultSkin) == true){
                text.text = "Equipped";
                ImportantVariables.skin = defaultSkin;
            }
            if (ImportantVariables.SkinsList.Contains(defaultSkin) == false){
                if (ImportantVariables.Money >= cost)
            {
                ImportantVariables.SkinsList.Add(defaultSkin);
                ImportantVariables.Money -= cost;
                text.text = "bought";
            }
            }





        }
        moneyAbility.text = ImportantVariables.Money.ToString("0");
        moneyShop.text = ImportantVariables.Money.ToString("0");
    }
}
