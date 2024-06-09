using UnityEngine;
using UnityEngine.EventSystems;

public class UIrefocus : MonoBehaviour
{
    private GameObject lastSelectedObject;

    void Start()
    {
        lastSelectedObject = EventSystem.current.currentSelectedGameObject;
    }

    void Update()
    {
        print(EventSystem.current.currentSelectedGameObject);
        GameObject currentSelectedObject = EventSystem.current.currentSelectedGameObject;
        if (currentSelectedObject == null && lastSelectedObject != null)
        {
            Debug.Log("Reselecting last selected input");
            EventSystem.current.SetSelectedGameObject(lastSelectedObject);
        }

        lastSelectedObject = currentSelectedObject;
    }
}
