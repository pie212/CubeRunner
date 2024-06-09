using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelNumb : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Levelnumber;
    

    // Update is called once per frame
    void Update()
    {
        //Levelnumber.text = GameManager.level.ToString("0");  // de "0" makes it display whole numbers instead of decimal ones
        Levelnumber.text = SceneManager.GetActiveScene().name;
    }
}
