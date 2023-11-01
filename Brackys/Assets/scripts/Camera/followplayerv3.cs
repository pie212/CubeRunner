
using UnityEngine;

public class followplayerv3 : MonoBehaviour
{
    public Transform target; // Reference to the player's Transform (car)
    public float rotationSpeed = 5.0f; // Adjust the speed of camera rotation

    void Update()
    {
        if (target != null)
        {
            // Interpolate between the current camera rotation and the player's rotation
            Quaternion desiredRotation = Quaternion.LookRotation(target.forward);

            // Smoothly rotate the camera to match the player's rotation
            transform.rotation = Quaternion.Slerp(Quaternion.Euler(0,transform.rotation.y,0), desiredRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
