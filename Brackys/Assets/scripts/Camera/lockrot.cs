using UnityEngine;

public class lockrot : MonoBehaviour
{
    public Transform player;
    private Quaternion initialRotation;

    void Start()
    {
        // Store the initial rotation of the object
        initialRotation = transform.rotation;
    }

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,1,-5);
        // Calculate the Y rotation based on the player's local rotation
        float yRotation = player.localEulerAngles.y;
        
        // Create a new rotation with the Y rotation as the only changing value
        Quaternion desiredRotation = Quaternion.Euler(0, yRotation, 0);
        
        // Apply the desired rotation while preserving the initial rotation's X and Z values
        transform.rotation = initialRotation * desiredRotation;
    }
}
