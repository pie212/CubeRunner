using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
public class PerkText : MonoBehaviour
{
    private Text perktext;
    // Start is called before the first frame update
    void Start()
    {
        perktext = GetComponentInChildren<Text>();
        perktext.text = "Upgraded Level " + FindObjectOfType<GameManager>().PerkMoneyCarrier.ToString();
    }

    // Update is called once per frame
    public void PerkMoney()
    {
        perktext.text = "Upgraded Level " + FindObjectOfType<GameManager>().PerkMoneyCarrier.ToString();
    }
}
