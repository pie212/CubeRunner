using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMobileControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform == true){
            gameObject.SetActive(true);
        }
        if (Application.isMobilePlatform == false){
            //gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
