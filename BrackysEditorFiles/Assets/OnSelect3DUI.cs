using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OnSelect3DUI : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public TextMeshPro text;

    public void OnSelect(BaseEventData eventData)
    {
        // Convert the hexadecimal color code to a Unity Color
        Color customColor = HexToColor("FF1F00");

        // Set the entire text to the custom color
        text.color = customColor;
        Debug.Log("Selected");
    }
    public void OnDeselect(BaseEventData eventData)
    {
        Color customColor = HexToColor("FFB400");

        // Set the entire text to the custom color
        text.color = customColor;
        Debug.Log("Selected");
    }

    public void OnClick(){
        Color customColor = HexToColor("FFB400");

        // Set the entire text to the custom color
        text.color = customColor;
        Debug.Log("Selected");
    }
    // Helper function to convert a hexadecimal color code to a Color object
    private Color HexToColor(string hex)
    {
        if (ColorUtility.TryParseHtmlString("#" + hex, out Color color))
        {
            return color;
        }
        return Color.white; // Default color (white) if parsing fails
    }

    
}
