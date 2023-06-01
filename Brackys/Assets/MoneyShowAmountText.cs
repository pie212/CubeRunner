using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class MoneyShowAmountText : MonoBehaviour
{
    //public GameManager GameManager;
    public Text Money;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Money.text = FindObjectOfType<GameManager>().MoneyButNotStatic.ToString("0");
    }
}
