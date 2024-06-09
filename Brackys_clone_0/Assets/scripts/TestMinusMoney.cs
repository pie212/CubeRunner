using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMinusMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoodbyeMoney(){

        ImportantVariables.Money -= 2;
       
        //Debug.Log(FindObjectOfType<GameManager>().money2);
    }
}
