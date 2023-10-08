
using UnityEngine;



public class RoadRot : MonoBehaviour{
// Assuming you have references to the cube and the road
public GameObject cube;
public GameObject road;
public float  speed = 10f;
void Update() {
    // Calculate the rotation to align the cube with the road
    Quaternion roadRotation = CalculateRoadRotation(cube.transform.position);

    // Apply the roadRotation to the cube
    
    //cube.transform.rotation = Quaternion.Lerp(cube.transform.rotation,roadRotation,0.1f);         FOR full rotation
    //cube.transform.rotation.y = Mathf.Lerp(cube.transform.rotation.y, roadRotation.y, 0.1f);      Doesnt work bruh


    // Add relative force to move the cube forward
    Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
    //cubeRigidbody.AddRelativeForce(Vector3.forward * speed); // Adjust speed as needed
}

Quaternion CalculateRoadRotation(Vector3 position) {
    RaycastHit hit;
    if (Physics.Raycast(position, -Vector3.up, out hit)) {
        // Get the normal vector of the road at the hit point
        
        Vector3 roadNormal = hit.normal;

        // Calculate the rotation that aligns the cube's up direction with the road's normal
        Quaternion roadRotation = Quaternion.FromToRotation(Vector3.up, roadNormal);

        return roadRotation;
    }
    // If no hit is detected, return the current rotation
    return cube.transform.rotation;
}
}




