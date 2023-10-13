using UnityEngine;
using System.Collections;

// Applies an explosion force to all nearby rigidbodies
public class explosiontest : MonoBehaviour
{
    public float radius = 50.0F;
    public float power = 10.0F;
    public bool boom = false;

    void FixedUpdate()
    {
        if (boom == true){
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                
        }
    }
    }

}