using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCAP : MonoBehaviour
{
    public int fps = 60;
     
    void Awake()
     {
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = fps;
     }
     
    void Update()
     {
         if(Application.targetFrameRate != fps);
             Application.targetFrameRate = fps;


     }

     
}


