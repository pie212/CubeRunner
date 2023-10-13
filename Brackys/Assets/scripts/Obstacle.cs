
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool IsForEffect = false;
    // Start is called before the first frame update
    private void OnCollision(Collider collision)
    {
        if (IsForEffect == false){
        if (collision.gameObject.tag == "Player" )
        {

            GetComponent<Rigidbody>().isKinematic = false;
        }
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (IsForEffect == false){
        
        if (collision.gameObject.tag == "Player" )
        {
            
            //rb.AddForce(100,0,0);
            //transform.position = new Vector3(transform.position.x,transform.position.y + 3,transform.position.z);
             if (GetComponent<Transform>().position.y < 8){              // random number 8 ig, sends it the other way (for the cubes up on the upside down levels)
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().AddForce(0, 3000 * Time.deltaTime,0, ForceMode.VelocityChange);
            }
            

            if (GetComponent<Transform>().position.y > 8){              // random number 8 ig, sends it the other way (for the cubes up on the upside down levels)
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().AddForce(0, -7000 * Time.deltaTime,0, ForceMode.VelocityChange);
            }
        }
        }
        

    }
    
    public void DestroyABL(int force){
        if (gameObject != null)
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, 50.0f);
            foreach (Collider hit in colliders)
            {
                
               

                if (hit.GetComponent<Rigidbody>() != null)
                {
                    
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.AddExplosionForce(force, explosionPos, 5.0F, 3.0F);
                
                    }
            }
        //Destroy(gameObject);
        
    
        }
    }
}