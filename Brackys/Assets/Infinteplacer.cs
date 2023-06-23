
using UnityEngine;

public class Infinteplacer : MonoBehaviour
{
    public GameObject ground;
    public GameObject groundUP;
    public GameObject groundUPSIDEDOWN;
    public GameObject groundDown;
    public int type;
    private float x;
    private float y;
    private float z;
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
            z = ground.transform.position.z + (220 * time);
            time += 1;  
            
            if (FindObjectOfType<GameManager>().Type == 1){
            chooser = Random.Range(1,3);
            if (chooser == 1){
            Instantiate(ground, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            FindObjectOfType<GameManager>().Type = 1;
            }
            if (chooser == 2){
            Instantiate(groundUP, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            FindObjectOfType<GameManager>().Type = 2;
            }
            }
            
            
            else if (FindObjectOfType<GameManager>().Type == 2)
            {
            Instantiate(groundUPSIDEDOWN, new Vector3(x,15,z), Quaternion.Euler(0,0,180));
            FindObjectOfType<GameManager>().Type = 3;
            
            }




            else if (FindObjectOfType<GameManager>().Type == 3)
            {
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
            Instantiate(ground, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            FindObjectOfType<GameManager>().Type = 1;
            
            }





            
        }
    }