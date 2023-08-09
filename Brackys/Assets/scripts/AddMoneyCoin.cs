
using UnityEngine;

public class AddMoneyCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            ImportantVariables.Money += (Random.Range(1,3));          // chooses amount of moeny based on perk level
             
            GetComponent<MeshRenderer>().enabled = false;
           
        }
    }
}
