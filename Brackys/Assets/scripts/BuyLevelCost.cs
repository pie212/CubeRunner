
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuyLevelCost : MonoBehaviour
{
    private TextMeshPro cost;
    public GameObject CostOBJ;           //Buy object because it contains the buy level script and holds the cost variable 
    // Start is called before the first frame update
    void Start()
    {
        cost = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        Invoke("SetText",0.02F);             // invoke is just for the delay since the Buy variable cant be accessed if the script activates at the same time
    }
    public void SetText()
    {
        Invoke("SetText",0.02F);
        cost.text = "Cost: " + CostOBJ.GetComponent<buylevel>().LevelCost.ToString();
    }
}
