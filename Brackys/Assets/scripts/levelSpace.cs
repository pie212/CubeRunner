using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSpace : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
    FindObjectOfType<PLayerMovement>().TorqueAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
