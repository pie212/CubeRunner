
using UnityEngine;

public class lockrot : MonoBehaviour
{
    private Quaternion initialRotation;
    public GameObject camhold;
    public GameObject player;
    void FixedUpdate(){
        GetComponent<Transform>().rotation = Quaternion.Euler(0,player.transform.rotation.y,0);
        GetComponent<Transform>().rotation = camhold.transform.rotation;
    }

}
