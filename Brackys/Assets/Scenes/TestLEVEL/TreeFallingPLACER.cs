using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFallingPLACER : MonoBehaviour
{
    public GameObject FallingTree;
    public int amount;
    private int x;
    private float y;
    private int z;
    
    // Start is called before the first frame update
    void Start()
    {
        

        
        
        Destroy(this);
        for(int i=0; i<amount  ; i++)            //amount i think
        {
            x =  Random.Range( 100,  297);         
            y = -0.6F;
            z =  Random.Range( 200,  855);
            Instantiate(FallingTree, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
        }
    }
}
