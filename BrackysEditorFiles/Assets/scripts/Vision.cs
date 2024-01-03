

using UnityEngine;

public class Vision : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Material DefMat;
    public Material LitMat;
    
    private void OnEnable()
    {
        EventManager.EagleEye += EventManagerOnEagleEye;
        EventManager.EagleEyeEnd += EventManagerOnEagleEyeEnd;
        
    }
    private void EventManagerOnEagleEye(){
        GetComponent<MeshRenderer>().material = LitMat;
    }
    private void EventManagerOnEagleEyeEnd(){
        GetComponent<MeshRenderer>().material = DefMat;
    }
    
    private void OnDisable()
    {
        EventManager.EagleEye -= EventManagerOnEagleEye;
        EventManager.EagleEyeEnd -= EventManagerOnEagleEyeEnd;

    }
}
