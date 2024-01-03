using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopskinchange : MonoBehaviour
{
    private MeshRenderer player;
    public GameManager gameManager;
    public List<Material> skins = new List<Material>();
    public int defaultSkin = 0;
    public Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
     player = GetComponent<MeshRenderer>();
     player.material = skins[defaultSkin]; 
    }

    // Update is called once per frame
    
    public void NextSkin()
    { 
        if (skins.Count > (defaultSkin +1 )){        // list comprehension
        _anim.SetTrigger("exit");
        Debug.Log("next");
        defaultSkin += 1;
        Invoke("skinChange", 0.5f);
        }
    }
    public void PreviousSkin(){
        if (0 < defaultSkin){
        _anim.SetTrigger("exit");
        defaultSkin -= 1;
        Invoke("skinChange", 0.5f);
        }

    }
    public void skinChange(){    // seprate function so we can use invoke for a slight delay
        player.material = skins[defaultSkin];
    }
}
