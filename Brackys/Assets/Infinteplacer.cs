using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinteplacer : MonoBehaviour
{
    public GameObject ground;
    private float x;
    private float y;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        x = ground.transform.position.x; 
        y = ground.transform.position.y; 
        z = ground.transform.position.z + 220;         //spacing between the blocks, perfect atm
        //Debug.Log(x);
        //Debug.Log(y);
        //Debug.Log(z);
    }

    void OnTriggerEnter(Collider other)   
    {
        if (other.tag == "Player")
        {
          Instantiate(ground, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
        }

    }
}
