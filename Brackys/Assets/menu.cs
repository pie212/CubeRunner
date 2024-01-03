using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraGltichFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // Get the Camera component attached to the GameObject
        Camera camera = GetComponent<Camera>();

        // Set the culling mask to render nothing
        camera.cullingMask = 0; // This will render nothing
        Invoke("starte", 0.5f);
        // To set the culling mask to render everything:
        // camera.cullingMask = -1; // This will render everything
    }
    public void starte(){
        GetComponent<Camera>().cullingMask = -1;
    }
}
