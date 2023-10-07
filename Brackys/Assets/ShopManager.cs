using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject Skins;
    public GameObject options;
    public GameObject Abilites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toAbility(){
        Skins.SetActive(false);
        Abilites.SetActive(true);
        options.SetActive(false);
    }
}
