using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinteplacerob : MonoBehaviour
{
    public GameObject ob;
    public GameObject ground;
    public GameObject powerup;
    public GameObject coin;
    public float amount;
    private float minx;
    private float maxx;
    private float miny;
    private float maxy;
    private float minz;
    private float maxz;
    private float aX;
    private float aZ;
    static float times = 1;
    // Start is called before the first frame update
    
    
    
    
    void Start()
    {
        minx = -10;
        maxx = 10;  
        maxy = 1; 
        minz = -10;         //spacing between the blocks, perfect atm
        maxz = 210;
        //Debug.Log(x);
        //Debug.Log(y);
        //Debug.Log(z);
        
    }

    public void ResetCord(){
        times = 1;
    }
    void OnTriggerEnter(Collider other)   
    {
        if (other.tag == "Player")
        {
            
            minz += 220 * times;
            maxz += 220 * times;
            times += 1;
            for(int i=0; i<50  ; i++)
            {
                aX = Random.Range(minx, maxx);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(ob, new Vector3(aX,maxy,aZ), Quaternion.Euler(0,0,0));
            }
            
             for(int q=0; q<5  ; q++){
                aX = Random.Range(-11, 11);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(powerup, new Vector3(aX,maxy,aZ), Quaternion.Euler(0,0,0));
            }
            for(int b=0; b<5  ; b++){
                aX = Random.Range(-11, 11);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(coin, new Vector3(aX,maxy,aZ), Quaternion.Euler(0,-90,90));
            }
            
        }
    }
}

