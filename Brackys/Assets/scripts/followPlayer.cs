
using UnityEngine;

public class followPlayer : MonoBehaviour
{
  public Transform player;
  public Vector3 offset;
  public Vector3 offsetUPsideown;
  public PLayerMovement movement;
    // Update is called once per frame
  void Update()
    {
    //if (movement.gravity == 1)
     //{
       // transform.position = player.position + offsetUPsideown;
      //}
      //if (movement.gravity == 0)
      //{
      transform.position = player.position + offset;
    }

    
    }

