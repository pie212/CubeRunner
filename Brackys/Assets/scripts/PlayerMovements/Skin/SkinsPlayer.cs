using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsPlayer : MonoBehaviour
{
    //public GameObject yourGameObject;
    //MeshFilter yourMesh;
    public MeshRenderer player;
    public Skins skin;
    public Material Skin1;
    public Material Skin2;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<MeshRenderer>();
        // yourMesh = yourGameObject.GetComponent<MeshFilter>();
   // yourMesh.sharedMesh = Resources.Load<Mesh>("Test");
        
        //meshrend.material = mat;
        if (skin.SKIN == 1){
            player.material = Skin1;
        }
        if (skin.SKIN == 2){
            player.material = Skin2;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
