
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
public class BuyLevelCost : MonoBehaviour
{
    private Text cost;
    public buylevel CostOBJ;           //Buy object because it contains the buy level script and holds the cost variable 
    // Start is called before the first frame update
    void Start()
    {
        cost = GetComponent<Text>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        Invoke("SetText",0.02F);             // invoke is just for the delay since the Buy variable cant be accessed if the script activates at the same time
    }
    public void SetText()
    {
        
        cost.text = CostOBJ.LevelCost.ToString();
    }
}
