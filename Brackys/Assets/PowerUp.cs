using System.Collections;
using System.Collections.Generic;
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
            PowerUpChoose = Random.Range(1, 5);
            Debug.Log(PowerUpChoose);
            if (PowerUpChoose == 4)
            {
                Debug.Log("INVINCIBLE!!");
                Debug.Log(FindObjectOfType<GameManager>().MoneyButNotStatic);
                FindObjectOfType<GameManager>().MoneyButNotStatic += MoneyAmount;
                FindObjectOfType<GameManager>().MoneyUpdated();
            } 

            Debug.Log("LEVEL UP!!");
            Mesh.enabled = false;
        }
    }
}
