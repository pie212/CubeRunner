
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollision(Collider collision)
    {
        if (collision.gameObject.tag == "Player" )
        {

            GetComponent<Rigidbody>().isKinematic = false;
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player" )
        {
            
            //rb.AddForce(100,0,0);
            //transform.position = new Vector3(transform.position.x,transform.position.y + 3,transform.position.z);
             if (GetComponent<Transform>().position.y < 8){              // random number 8 ig, sends it the other way (for the cubes up on the upside down levels)
                GetComponent<Rigidbody>().AddForce(0, 3000 * Time.deltaTime,0, ForceMode.VelocityChange);
            }
            

            if (GetComponent<Transform>().position.y > 8){              // random number 8 ig, sends it the other way (for the cubes up on the upside down levels)
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().AddForce(0, -7000 * Time.deltaTime,0, ForceMode.VelocityChange);
            }
           
        }
        

    }
    

    
}