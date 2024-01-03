using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 offset;
    // Start is called before the first frame update
    public Animator animation;
    void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        Debug.Log("Oh yeah!!");
        animation.SetBool("Up", true);
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        Debug.Log("Goodbye!!");
        animation.SetBool("Up", false);
        
    }
}
