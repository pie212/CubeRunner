
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    
    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");  // de "0" makes it display whole numbers instead of decimal ones
    }
}
