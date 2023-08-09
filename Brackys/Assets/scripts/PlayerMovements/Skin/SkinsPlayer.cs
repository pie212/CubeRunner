using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsPlayer : MonoBehaviour
{
    //public GameObject yourGameObject;
    //MeshFilter yourMesh;
    public MeshRenderer player;
    public GameManager gameManager;
    public Material Skin1;
    public Material Skin2;
    public Material Skin3;
    public Material Skin4;
    public Material Skin5;
    

    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<MeshRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        // yourMesh = yourGameObject.GetComponent<MeshFilter>();
   // yourMesh.sharedMesh = Resources.Load<Mesh>("Test");
        
        //meshrend.material = mat;
        if (ImportantVariables.skin == 1){
            player.material = Skin1;
        }
        if (ImportantVariables.skin == 2){
            player.material = Skin2;
        }
        if (ImportantVariables.skin == 3){
            player.material = Skin3;
        }
        if (ImportantVariables.skin == 4){
            player.material = Skin4;
        }
        if (ImportantVariables.skin == 5){
            player.material = Skin5;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
