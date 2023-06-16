using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAllowed : MonoBehaviour
{
    public static List<int> AllowedLevelsStat = new List<int>();
    public List<int> AllowedLevels = new List<int>();
    public int AddedLevel;
    // Start is called before the first frame update
    void Start(){
        AllowedLevels = AllowedLevelsStat;
        if (AllowedLevelsStat.Contains(1) == false)
        {
            
            AllowedLevelsStat.Add(1);
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
            AllowedLevelsStat.Add(AddedLevel);
            AllowedLevels = AllowedLevelsStat;
            Debug.Log("cheese");
            foreach( var x in AllowedLevels) {
            Debug.Log( x.ToString());}
        //}
    }
}
