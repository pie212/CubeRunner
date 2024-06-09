using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Networking;

public class FollowCameraNetwork : NetworkBehaviour
{

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { Destroy(this); }
    }

    public Transform player;

    public Vector3 offset;
    public Vector3 offsetUPsideown;
    public float smoothSpeed;
    private Vector3 velocity = Vector3.zero;
    private Vector3 smoothedPosition;
    private Vector3 desiredPosition;
    //public PLayerMovement movement;
    // Update is called once per frame
    void LateUpdate()
    {
        desiredPosition = player.position + offset;

        smoothedPosition.x = Mathf.SmoothDamp(transform.position.x, desiredPosition.x, ref velocity.x, 0.05f * Time.timeScale);
        smoothedPosition.y = Mathf.SmoothDamp(transform.position.y, desiredPosition.y, ref velocity.y, 0.05f * Time.timeScale);
        // smoothedPosition.z = Mathf.SmoothDamp(transform.position.z, desiredPosition.z, ref velocity.z, 0.01f* Time.timeScale);

        // // Smoothly move the camera to the desired position using SmoothDamp
        // transform.position = Vector3.SmoothDamp(transform.position, smoothedPosition, ref velocity, smoothSpeed);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, desiredPosition.z);
    }
}
