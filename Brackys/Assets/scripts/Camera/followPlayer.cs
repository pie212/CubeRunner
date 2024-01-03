





using System.Runtime;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
  public Transform player;
  
  public Vector3 offset;
  public Vector3 offsetUPsideown;
  public float smoothSpeed;
  //public PLayerMovement movement;
    // Update is called once per frame
  void LateUpdate()
    {
    //if (movement.gravity == 1)
     //{ 
       // transform.position = player.position + offsetUPsideown;
      //}
      //if (movement.gravity == 0)
      //{
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;
       
    }

    
    }

