using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texturechanger : MonoBehaviour
{
    public Material tex;
    //public GameObject self;         // gameobject that changes

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.z <= GameObject.Find("Player").GetComponent<Transform>().position.z)
        {
            GetComponent<MeshRenderer>().material = tex;
        }
    }
}
