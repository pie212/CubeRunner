using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMobile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform == true){
            gameObject.SetActive(false);
        }
        if (Application.isMobilePlatform == false){
            gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
