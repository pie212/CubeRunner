using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerupTypeUI : MonoBehaviour
{
    //public Image explosion;
    public Sprite DefaultState;
    public Sprite PowerUp1;
    public Sprite PowerUp2;
    public Sprite PowerUp3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        if (FindObjectOfType<GameManager>().PowerUpType == 0){

        
            GetComponent<Image>().sprite = DefaultState;
            
        }
        if (FindObjectOfType<GameManager>().PowerUpType == 1)
        {
            GetComponent<Image>().sprite = PowerUp1;
        }
        if (FindObjectOfType<GameManager>().PowerUpType == 2)
        {
            GetComponent<Image>().sprite = PowerUp2;
        }
        if (FindObjectOfType<GameManager>().PowerUpType == 3)
        {
            GetComponent<Image>().sprite = PowerUp3;
        }
        
        
    }
}
