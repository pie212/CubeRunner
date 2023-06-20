
using UnityEngine;

public class AddMoneyCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().MoneyButNotStatic += (Random.Range(1,3)*FindObjectOfType<GameManager>().PerkMoneyCarrier);          // chooses amount of moeny based on perk level
            FindObjectOfType<GameManager>().MoneyUpdated(); 
            GetComponent<MeshRenderer>().enabled = false;
            Debug.Log(FindObjectOfType<GameManager>().MoneyButNotStatic);
        }
    }
}
