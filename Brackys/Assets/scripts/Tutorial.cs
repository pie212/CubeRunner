using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [Header("General")]
    [Header("4000 speed is normal")]
    public bool SlowPlayer;
    public float SlowSpeed;
    [Header("Desktop")]
    public GameObject[] DesktopControls;
    public Image[] DesktopImageControls;
    [Header("Controller")]
    public GameObject[] ControlerControls;
    public Image[] ControlerImageMap;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < DesktopControls.Length; i++)
        {
            DesktopControls[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < DesktopImageControls.Length; i++)
        {
            DesktopImageControls[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < ControlerControls.Length; i++)
        {
            ControlerControls[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < ControlerImageMap.Length; i++)
        {
            ControlerImageMap[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //Called when something is colliding with the area
    {
        if (PlayerCollision.hasDied == true && other.tag == "Player") //If the player has died and the player is in the intro area then:
        {
            if (ImportantVariables.MouseVisible) // MouseVisible =1 means keyboard-mouse mode and =0 means controler mode
            {
                //sets the player speed slower if SlowPlayer is true
                if (SlowPlayer)
                {
                    FindObjectOfType<PLayerMovement>().forwardForce = SlowSpeed;
                }


                for (int i = 0; i < DesktopControls.Length; i++)
                {
                    DesktopControls[i].gameObject.SetActive(true);
                }
                for (int i = 0; i < DesktopImageControls.Length; i++)
                {
                    DesktopImageControls[i].gameObject.SetActive(true);
                }
            }
            else
            {
                if (SlowPlayer)
                {
                    FindObjectOfType<PLayerMovement>().forwardForce = SlowSpeed;
                }

                for (int i = 0; i < ControlerControls.Length; i++)
                {
                    ControlerControls[i].gameObject.SetActive(true);
                }
                for (int i = 0; i < ControlerImageMap.Length; i++)
                {
                    ControlerImageMap[i].gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("left");

        if (other.transform.name == "Player")
        {
            FindObjectOfType<PLayerMovement>().forwardForce = 4000f;
            


            for (int i = 0; i < DesktopControls.Length; i++)
            {
                DesktopControls[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < DesktopImageControls.Length; i++)
            {
                DesktopImageControls[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < ControlerControls.Length; i++)
            {
                ControlerControls[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < ControlerImageMap.Length; i++)
            {
                ControlerImageMap[i].gameObject.SetActive(false);
            }
        }
        
    }
}
