using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
    public GameObject Object;
    public int amount;
    private int x;
    private float y;
    private int z;
    public int MaxX;
    public int MaxZ;
    public int MinX;
    public int MinZ;
    public float Y;
    // inputs player


    
    // Start is called before the first frame update
    void Start()
    {
        

        
        
        Destroy(this);
        for(int i=0; i<amount  ; i++)            //amount i think
        {
            x =  Random.Range( MinX,  MaxX);         
            y = Y;
            z =  Random.Range( MinZ,  MaxZ);
            Instantiate(Object, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
        }
    }
}

