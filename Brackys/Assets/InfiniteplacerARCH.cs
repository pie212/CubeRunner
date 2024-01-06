

using UnityEngine;

public class InfinteplacerARCH : MonoBehaviour
{
    public GameObject groundnormal;     //1
    public GameObject bladesnormal;    //2 
    public GameObject hammernormal;   // 3
    public GameObject spikesnormal;    // 4
    public GameObject groundUP;     // 5
    public GameObject groundupsidedown;      //6 
    public GameObject bladesupsidedown;     //7
    public GameObject hammerupsidedown;     //8 
    public GameObject spikesupsidedown;    //9
    public GameObject groundDOWN;          // 10
    public GameObject fog;         
    public int type = 1;
    
    //fog
    private float minFOG = 0;
    private float maxFOG = 1;
    private float t;
    
    private float x;
    private float y;
    private float z;
    public int colorChooser;
    public int chooser;
    public int time = 1;
    // Start is called before the first frame update
    void Start()
    {
        x = groundnormal.transform.position.x; 
        y = groundnormal.transform.position.y; 
                //spacing between the blocks, perfect atm
        //Debug.Log(x);
        //Debug.Log(y);
        //Debug.Log(z);
    }

    public void placeit()   
    {
         
        













            
            z = groundnormal.transform.position.z + (220 * time);         // calculates the groundnormal position, plus the amount of times, but this seems to always be 1 uh where is this changeed??
            
            
            Instantiate(fog, new Vector3(x,y,z), Quaternion.Euler(0,0,0));                // this is for the fog, the white fog
            
            
            // Type 1 = reg groundnormal
            // Type 2 = groundup
            // Type 3 = reg upsideown
            // type 4 = upsidedown goes down

            if (type == 1 ||type == 2 || type == 3||type == 4 || type == 10)   // if floor is regular
            {                                   
                
             
                                                                            // default value when starting
            chooser = Random.Range(1,6);                                    // chooser choosese between 2 options for when that happens
            if (chooser == 1){                          // next piece of logic choses if we continue regular road, or if we go up...  -->normal
            Instantiate(groundnormal, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 1;
            }
            if (chooser == 2){                                       // -->up
            Instantiate(groundUP, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 2;
            }
            if (chooser == 3){                                       // -->up
            Instantiate(groundUP, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 3;
            }
            if (chooser == 4){                                       // -->up
            Instantiate(groundUP, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 4;
            }
            if (chooser == 5){                                       // -->up
            Instantiate(groundUP, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 5;
            }
            
            }
            else if (type == 5 || type == 6 || type == 7 || type == 8|| type == 9) 
            {
            chooser = Random.Range(6,11);
            if (chooser == 6){                          // next piece of logic choses if we continue regular road, or if we go up...  -->normal
            Instantiate(groundupsidedown, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 6;
            }
            if (chooser == 7){                          // next piece of logic choses if we continue regular road, or if we go up...  -->normal
            Instantiate(bladesupsidedown, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 7;
            }
            if (chooser == 8){                                       // -->up
            Instantiate(hammerupsidedown, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 8;
            }
            if (chooser == 9){                                       // -->up
            Instantiate(spikesupsidedown, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 9;
            }
            if (chooser == 10){                                       // -->up
            Instantiate(groundDOWN, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            type = 10;
            }
            
            }
        }
            
            















    
}