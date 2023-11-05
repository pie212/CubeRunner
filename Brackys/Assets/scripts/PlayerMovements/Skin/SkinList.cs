using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinList : MonoBehaviour      // not needed anymore this script is not needed
{
    public static List<int> SkinsList = new List<int>();
    public List<int> SkinsListPUB = new List<int>();
    public int TypeAdd;


    // Update is called once per frame
        public void AddToSkin(){
        
        ImportantVariables.SkinsList.Add(TypeAdd);
        
        
        
    }
}
