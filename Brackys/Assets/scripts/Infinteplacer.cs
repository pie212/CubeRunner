

using UnityEngine;

public class Infinteplacer : MonoBehaviour
{
    public GameObject ground;
    public GameObject groundUP;
    public GameObject groundUPSIDEDOWN;
    public GameObject groundDown;
    public GameObject fog;
    private GameObject Light;
    public GameObject Blue;
    public GameObject Red;
    public GameObject Green;
    public GameObject backround;
    
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
        x = ground.transform.position.x; 
        y = ground.transform.position.y; 
                //spacing between the blocks, perfect atm
        //Debug.Log(x);
        //Debug.Log(y);
        //Debug.Log(z);
    }

    public void placeit()   
    {
         RenderSettings.fogDensity = Mathf.Lerp(minFOG, maxFOG, t);    // fog or some shit
        













            
            z = ground.transform.position.z + (220 * time);         // calculates the ground position, plus the amount of times, but this seems to always be 1 uh where is this changeed??
            colorChooser = Random.Range(1,4);
            Debug.Log(colorChooser);
            if (colorChooser == 1)                              // this is for the fancy cool cube lightss
            {
                Light = Blue;
                
            }
            if (colorChooser == 2)
            {
                Light = Red;
                
            }
            if (colorChooser == 3)
            {
                Light = Green;
                
            }
            
            Instantiate(fog, new Vector3(x,y,z), Quaternion.Euler(0,0,0));                // this is for the fog, the white fog
            
            // Type 1 = reg ground
            // Type 2 = groundup
            // Type 3 = reg upsideown
            // type 4 = upsidedown goes down

            if (FindObjectOfType<GameManager>().Type == 1)   // if floor is regular
            {                                   
                
            for(int i=0; i<25  ; i++)  // loop
            {
            GameObject newObject = Instantiate(Light, new Vector3(Random.Range(-12,12),Random.Range(5,15),Random.Range(220*time, 220*(time+1))), Quaternion.Euler(Random.Range(0,91),Random.Range(0,91),Random.Range(0,91)));
            newObject.transform.localScale = new Vector3(Random.Range(1,3), Random.Range(1,3),Random.Range(1,3));         // adds cube lights in desired positins
            }    
                                                                            // default value when starting
            chooser = Random.Range(1,3);                                    // chooser choosese between 2 options for when that happens
            if (chooser == 1){                          // next piece of logic choses if we continue regular road, or if we go up...  -->normal
            Instantiate(ground, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            FindObjectOfType<GameManager>().Type = 1;
            }
            if (chooser == 2){                                       // -->up
            Instantiate(groundUP, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            FindObjectOfType<GameManager>().Type = 2;
            }
            }
            
            
            else if (FindObjectOfType<GameManager>().Type == 2) // if floor is going up 
            {
            for(int i=0; i<25  ; i++)  // adds cube lights in desired positins
            {
            GameObject newObject = Instantiate(Light, new Vector3(Random.Range(-12,12),Random.Range(-10,0),Random.Range(220*time, 220*(time+1))), Quaternion.Euler(Random.Range(0,91),Random.Range(0,91),Random.Range(0,91)));
            newObject.transform.localScale = new Vector3(Random.Range(1,3), Random.Range(1,3),Random.Range(1,3));
            }


            Instantiate(groundUPSIDEDOWN, new Vector3(x,15,z), Quaternion.Euler(0,0,180));
            FindObjectOfType<GameManager>().Type = 3;
            }




            else if (FindObjectOfType<GameManager>().Type == 3)
            {
            for(int i=0; i<25  ; i++)
            {
            GameObject newObject = Instantiate(Light, new Vector3(Random.Range(-12,12),Random.Range(-10,0),Random.Range(220*time, 220*(time+1))), Quaternion.Euler(Random.Range(0,91),Random.Range(0,91),Random.Range(0,91)));
            newObject.transform.localScale = new Vector3(Random.Range(1,3), Random.Range(1,3),Random.Range(1,3));
            }



            chooser = Random.Range(1,3);
            if (chooser == 1)
            {
            Instantiate(groundUPSIDEDOWN, new Vector3(x,15,z), Quaternion.Euler(0,0,180));
            FindObjectOfType<GameManager>().Type = 3;
            }
            if (chooser == 2)
            {
            Instantiate(groundDown, new Vector3(x,15,z), Quaternion.Euler(0,0,180));
            FindObjectOfType<GameManager>().Type = 4;
            }
            }

            
            else if (FindObjectOfType<GameManager>().Type == 4)
            {
            for(int i=0; i<25  ; i++)
            {
            GameObject newObject = Instantiate(Light, new Vector3(Random.Range(-12,12),Random.Range(5,15),Random.Range(220*time, 220*(time+1))), Quaternion.Euler(Random.Range(0,91),Random.Range(0,91),Random.Range(0,91)));
            newObject.transform.localScale = new Vector3(Random.Range(1,3), Random.Range(1,3),Random.Range(1,3));
            }
            Instantiate(ground, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            FindObjectOfType<GameManager>().Type = 1;
            
            }
            FindObjectOfType<Infinteplacerob>().waiter();
            



            Instantiate(backround, new Vector3(x,y,z-110), Quaternion.Euler(0,0,0));
            
        }















    }