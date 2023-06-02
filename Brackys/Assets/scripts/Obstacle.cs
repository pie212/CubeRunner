using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" ){
            transform.position = new Vector3(transform.position.x,transform.position.y + 3,transform.position.z);
        }
}
}