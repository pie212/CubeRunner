





using System.Runtime;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
  public Transform player;
  
  public Vector3 offset;
  public Vector3 offsetUPsideown;
  public float smoothSpeed;
  private Vector3 velocity = Vector3.zero;
  private Vector3 smoothedPosition;
  private  Vector3 desiredPosition;
  //public PLayerMovement movement;
    // Update is called once per frame
  void LateUpdate()
    {
      Debug.Log(Time.timeScale);
    if (FindObjectOfType<PLayerMovement>().gravity == 1) // if we are upside down
     { 
       desiredPosition = player.position + offsetUPsideown;
      }
      if (FindObjectOfType<PLayerMovement>().gravity == 0)
      {
        // Vector3 desiredPosition = player.position + offset;                                         //old system
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  // old system
        
        // transform.position = smoothedPosition;
        desiredPosition = player.position + offset;
      }
        
        smoothedPosition.x = Mathf.SmoothDamp(transform.position.x, desiredPosition.x, ref velocity.x, 0.05f* Time.timeScale);
        smoothedPosition.y = Mathf.SmoothDamp(transform.position.y, desiredPosition.y, ref velocity.y, 0.05f* Time.timeScale);
        smoothedPosition.z = Mathf.SmoothDamp(transform.position.z, desiredPosition.z, ref velocity.z, 0.01f* Time.timeScale);

        // Smoothly move the camera to the desired position using SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, smoothedPosition, ref velocity, smoothSpeed);
    }

    
    }

