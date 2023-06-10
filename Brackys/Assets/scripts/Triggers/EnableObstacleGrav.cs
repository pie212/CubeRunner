using System.Xml.Serialization;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObstacleGrav : MonoBehaviour
{
    private Collider Area;
    void start(){
        Area = GetComponentInChildren<Collider>();
    }
    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
        Debug.Log("Works");
            Area.enabled = true;
        }
    }
}
