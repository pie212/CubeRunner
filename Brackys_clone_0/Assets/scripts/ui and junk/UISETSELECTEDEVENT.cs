using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;
public class UISETSELECTEDEVENT : MonoBehaviour
{
    public GameObject itemsButton;
    EventSystem m_EventSystem;
    //private EventSystem eventSystem;
    // Start is called before the first frame update
    public void LevelEnd()
    {
        m_EventSystem = EventSystem.current;
        m_EventSystem.SetSelectedGameObject(itemsButton);
    }
}
