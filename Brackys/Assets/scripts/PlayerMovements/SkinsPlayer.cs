using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsPlayer : MonoBehaviour
{
    public GameObject yourGameObject;
    MeshFilter yourMesh;
    

    // Start is called before the first frame update
    void Start()
    {
         yourMesh = yourGameObject.GetComponent<MeshFilter>();
    yourMesh.sharedMesh = Resources.Load<Mesh>("Test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
