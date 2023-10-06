using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ability : MonoBehaviour
{
    public int numberAblity = 1;
    public static bool bought = false;
    public Text costtext;
    // Start is called before the first frame update
    void Start()
    {
        if (bought = true){
            costtext.text = "ooga";
        }
        else{
            costtext.text = "booga";
        }
    }
    public void click(){
        if (!ImportantVariables.AbilityList.Contains(numberAblity)){
        ImportantVariables.AbilityList.Add(numberAblity);
        }
        else{
            ImportantVariables.AbilityNumb = numberAblity; 
        }
        EventManager.OnUpdateABLUI();
    }
    // Update is called once per frame
    public void UIupdate(){
        Debug.Log(ImportantVariables.AbilityList);
        Debug.Log(ImportantVariables.AbilityNumb);
        if (numberAblity == ImportantVariables.AbilityNumb){
            costtext.text = "Equipped";
        }
        else if (ImportantVariables.AbilityList.Contains(numberAblity)){
            costtext.text = "Bought";
        }
        else{
            costtext.text = "Buy";
        }
        
    }
    private void OnEnable()
    {
        EventManager.UpdateABLUI += EventManagerOnUpdateABLUI;
        
    }
    private void EventManagerOnUpdateABLUI()
    {
        UIupdate();
      
      
    }
    private void OnDisable()
    {
        EventManager.UpdateABLUI -= EventManagerOnUpdateABLUI;

    }
}
