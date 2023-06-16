
using UnityEngine;

public class AddMoneyCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().MoneyButNotStatic += 3;
            FindObjectOfType<GameManager>().MoneyUpdated();
            GetComponent<MeshRenderer>().enabled = false;
            Debug.Log(FindObjectOfType<GameManager>().MoneyButNotStatic);
        }
    }
}
