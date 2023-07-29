
using UnityEngine;

public class KaboomRadiusHolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().rotation =  Quaternion.Euler(0, 0, 0);

    }
}
