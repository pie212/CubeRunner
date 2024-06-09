using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tntBlock : MonoBehaviour
{
    public ParticleSystem kaboomeffect;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player" )
        {
            Debug.Log("We collided?!?!?!!?!?!?!?");
            kaboomeffect.Play();
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
                        rb.AddExplosionForce(1000, explosionPos, 5.0F, 3.0F);
                    
                        }
                }
        
            }
        
        }
    }
}
