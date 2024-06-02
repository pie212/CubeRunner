

using UnityEngine;

public class Infinteplacerob : MonoBehaviour
{
    public GameObject ob;
    public GameObject powerup;
    public GameObject coin;
    public GameObject tnt;
    public float amount;
    private float minx;
    private float maxx;
    private float miny;
    private float maxy;
    private float minz;
    private float maxz;
    private float aX;
    private float aZ;
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

    //
        //public void ResetCord(){
        //times = 1;
    //}
    public void waiter(){
        Invoke("objects",1);
    }
    public void objects()   
    {            
            minz += 220;
            maxz += 220; 
            GetComponent<Infinteplacer>().time += 1;
            if (FindObjectOfType<GameManager>().Type == 1 || FindObjectOfType<GameManager>().Type == 2 )
            {
                ob.GetComponent<Rigidbody>().useGravity = true;   
                tnt.GetComponent<Rigidbody>().useGravity = true;   
            for(int i=0; i<Random.Range(45,60)  ; i++)
                {
                aX = Random.Range(minx, maxx);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(ob, new Vector3(aX,maxy,aZ), Quaternion.Euler(0,0,0));
                }
            
             for(int q=0; q<Random.Range(2,5)  ; q++)
                {
                aX = Random.Range(-11, 11);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(powerup, new Vector3(aX,1.7F,aZ), Quaternion.Euler(0,0,0));
                }
            for(int b=0; b<Random.Range(3,15)  ; b++){
                aX = Random.Range(-11, 11);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(coin, new Vector3(aX,1.7F,aZ), Quaternion.Euler(0,-90,90));
            }
            for(int i=0; i<Random.Range(4,15)  ; i++)
                {
                aX = Random.Range(minx, maxx);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(tnt, new Vector3(aX,maxy,aZ), Quaternion.Euler(0,0,0));
                }
            
            }




            if (FindObjectOfType<GameManager>().Type == 3 || FindObjectOfType<GameManager>().Type == 4 )
            {   
            ob.GetComponent<Rigidbody>().useGravity = false;
            tnt.GetComponent<Rigidbody>().useGravity = false;  
            for(int i=0; i<Random.Range(45,60)  ; i++)
            {   
                aX = Random.Range(minx, maxx);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(ob, new Vector3(aX,14,aZ), Quaternion.Euler(0,0,0));
            }
             for(int q=0; q<8  ; q++){
                aX = Random.Range(-11, 11);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(powerup, new Vector3(aX,13,aZ), Quaternion.Euler(0,0,180));
            }
            for(int b=0; b<5  ; b++){
                aX = Random.Range(-11, 11);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(coin, new Vector3(aX,13,aZ), Quaternion.Euler(0,-90,90));
            }
            for(int i=0; i<Random.Range(4,15)  ; i++)
            {   
                aX = Random.Range(minx, maxx);
                aZ = Random.Range(minz,maxz + 1);
                Instantiate(tnt, new Vector3(aX,14,aZ), Quaternion.Euler(0,0,0));
            }
            }
    }
}

