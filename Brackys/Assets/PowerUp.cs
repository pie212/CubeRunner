using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public MeshRenderer Mesh;
    private Vector3 pos;
    //private Quaternion rot;
    public Vector3 offsetPos;
    //public Quaternion offsetRot;
    public Vector3 rotateAmount = new Vector3(50,0,0);

    
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
        //transform.rotation = rot * offsetRot;  
        transform.Rotate(rotateAmount * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("LEVLE UP!!");
            Mesh.enabled = false;
        }
    }
}
