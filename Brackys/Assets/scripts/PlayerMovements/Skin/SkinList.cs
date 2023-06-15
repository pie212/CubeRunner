using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinList : MonoBehaviour
{
    public static List<int> SkinsList = new List<int>();
    public List<int> SkinsListPUB = new List<int>();
    public int TypeAdd;


    // Update is called once per frame
    void Start(){
        SkinsListPUB = SkinsList;
    }
    public void AddToSkin(){
        
        SkinsList.Add(TypeAdd);
        SkinsListPUB = SkinsList;
        foreach( var x in SkinsList) {
        Debug.Log( x.ToString());

        }
        
    }
}
