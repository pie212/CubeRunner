using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placerCol : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)   
    {
        if (other.tag == "Player")
        FindObjectOfType<Infinteplacer>().placeit();
    }
}
