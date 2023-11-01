using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlacer : MonoBehaviour
{
    public GameObject Car;
    public GameObject spawnpos1;
    public GameObject spawnpos2;
    public GameObject spawnpos3;
    // Start is called before the first frame update
    void Start()
    {
        placecar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void placecar(){
        int a = Random.Range(0,4);
        if (a == 1){
            Instantiate(Car, spawnpos1.transform.position, Quaternion.Euler(0,0,0));
        }
        else if (a == 2){
            Instantiate(Car, spawnpos2.transform.position, Quaternion.Euler(0,0,0));
        }
        else if (a == 3){
            Instantiate(Car, spawnpos2.transform.position, Quaternion.Euler(0,0,0));
        }
        Invoke("placecar", 3);
    }
}
