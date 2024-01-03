

using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Video;

public class ShopAbilityChange : MonoBehaviour
{
    
    
    public VideoPlayer vid;

    public List<VideoClip> clips = new List<VideoClip>();

    public List<int> costs = new List<int>();                                         //  0 = first cost, 1 = seoncnd cost, 3 = third cost

    public int Ability = 1;        // 0 = none, 1 = slowmo eagle eye, 2 = explosion, 3 = normal slowmo
    public Text costtext;
    // Start is called before the first frame update
    void Start()
    {
        
        if (Ability == ImportantVariables.AbilityNumb){
            costtext.text = "Equipped";
        }
        else if (ImportantVariables.AbilityList.Contains(Ability)){
            costtext.text = "Bought";
        }
        else{
            costtext.text = "Cost: " + costs[Ability - 1].ToString();
        }
    }

    public void BuyAbility(){
        Debug.Log(costs[Ability - 1]);
        if (!ImportantVariables.AbilityList.Contains(Ability) && ImportantVariables.Money >= costs[Ability - 1]) {
                ImportantVariables.Money -= costs[Ability - 1];
                ImportantVariables.AbilityList.Add(Ability);
        }
        else if (ImportantVariables.AbilityList.Contains(Ability)){
            ImportantVariables.AbilityNumb = Ability; 
        }
        if (Ability == ImportantVariables.AbilityNumb){
            costtext.text = "Equipped";
        }
        else if (ImportantVariables.AbilityList.Contains(Ability)){
            costtext.text = "Bought";
        }
        else{
            costtext.text = "Cost: " + costs[Ability - 1].ToString();
        }


    }
    // Update is called once per frame
    public void NextAbility ()
    {
        if (Ability < 3){
    Ability += 1;
    vid.clip = clips[Ability - 1];
    UpdateUI();
        }
    }
    public void PreviousAbility ()
    {
        if (Ability > 0){
            Ability -= 1;
            vid.clip = clips[Ability - 1];
            UpdateUI();
        }

    }
    public void UpdateUI(){
        if (Ability == ImportantVariables.AbilityNumb){
            costtext.text = "Equipped";
        }
        else if (ImportantVariables.AbilityList.Contains(Ability)){
            costtext.text = "Bought";
        }
        else{
            costtext.text = "Cost: " + costs[Ability - 1].ToString();
        }
    }
}
