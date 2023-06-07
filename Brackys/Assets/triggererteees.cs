using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggererteees : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        terrain.GetComponent<TerrainCollider> ().enabled = false;
        terrain.GetComponent<TerrainCollider> ().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
