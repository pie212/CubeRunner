using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMinusMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoodbyeMoney(){

        FindObjectOfType<GameManager>().MoneyButNotStatic -= 2;
        FindObjectOfType<GameManager>().MoneyUpdated();
        //Debug.Log(FindObjectOfType<GameManager>().money2);
    }
}
