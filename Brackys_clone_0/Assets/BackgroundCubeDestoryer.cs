using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCubeDestoryer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerView")
        {
            Destroy(other.gameObject);
        }
    }
}
