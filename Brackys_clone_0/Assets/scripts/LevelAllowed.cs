using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelAllowed : MonoBehaviour
{
    public static List<int> AllowedLevelsStat = new List<int>();
    public List<int> AllowedLevels = new List<int>();
    public int AddedLevel;
    // Start is called before the first frame update
    void Start(){
        
        //AllowedLevels = AllowedLevelsStat;
        if (ImportantVariables.LevelAllowed.Contains(1) == false)
        {
            
            ImportantVariables.LevelAllowed.Add(1);
            foreach( var x in AllowedLevels) {
            Debug.Log( x.ToString());}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddLevel()
    {
        //if (AllowedLevelsStat.Contains(AddedLevel) == false)
        //{
        bool containsAllNumbers = Enumerable.Range(1, AddedLevel - 1).All(ImportantVariables.LevelAllowed.Contains);

        if (containsAllNumbers){
            Debug.Log("Ighty this works good job");
            ImportantVariables.LevelAllowed.Add(AddedLevel);
            //AllowedLevels = AllowedLevelsStat;
            //Debug.Log("cheese");
            foreach( var x in ImportantVariables.LevelAllowed) {
            Debug.Log( x.ToString());}
        }
            
        //}
    }
    public void BuyLevel(){
        ImportantVariables.LevelAllowed.Add(AddedLevel);
        //AllowedLevels = AllowedLevelsStat;
    }
}
