using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsPlayer : MonoBehaviour
{
    //public GameObject yourGameObject;
    //MeshFilter yourMesh;
    public MeshRenderer meshrend;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        // yourMesh = yourGameObject.GetComponent<MeshFilter>();
   // yourMesh.sharedMesh = Resources.Load<Mesh>("Test");
        
        meshrend.material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
