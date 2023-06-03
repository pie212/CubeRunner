

using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public MeshRenderer Mesh;
    private Vector3 pos;
    //private Quaternion rot;
    public Vector3 offsetPos;
    //public Quaternion offsetRot = Quaternion.Euler(0,0,0);
    public Vector3 rotateAmount = new Vector3(50,0,0);
    private int PowerUpChoose;
    public int MoneyAmount = 1;

    
    // Start is called before the first frame update
    void Start()
    
    {
        pos = transform.position;
        //rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        // makes stuff go spin and up

        transform.position = pos + offsetPos;
        //transform.rotation = rot * offsetRot; //offsetRot;  // (0,0,0) * (0,45,0)     Vector3(2.2,5) + Vector(5,5,2) = Vector(7.7,7)
        transform.Rotate(rotateAmount * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PowerUpChoose = Random.Range(1,3); //Random.Range(1, 2);
            Debug.Log(PowerUpChoose);
            if (PowerUpChoose == 3)
            {
                Debug.Log("INVINCIBLE!!");
                Debug.Log(FindObjectOfType<GameManager>().MoneyButNotStatic);
                FindObjectOfType<GameManager>().MoneyButNotStatic += MoneyAmount;
                FindObjectOfType<GameManager>().MoneyUpdated();
            } 
            if (PowerUpChoose == 1){
                Debug.Log("kaboom rico!");
                FindObjectOfType<GameManager>().PowerUpType = 1;
            }
            if (PowerUpChoose == 2){
                Debug.Log("ANOTHER LIFE FOR YOU!");
                FindObjectOfType<GameManager>().PowerUpType = 2;
            }

            Debug.Log("LEVEL UP!!");
            Mesh.enabled = false;
        }
    }
}
