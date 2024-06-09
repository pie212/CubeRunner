

using UnityEngine;

public class followrotationcam : MonoBehaviour
{
    
  public float rotSpeed;
  public Transform player;
  
    // Start is called before the first frame update
    void LateUpdate(){
      
        Debug.Log(player.transform.eulerAngles.y);
        Quaternion desiredRotation = Quaternion.Euler(0,player.transform.eulerAngles.y,0);
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotSpeed);
        
        transform.rotation = smoothedRotation;
    }
}
