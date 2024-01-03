using UnityEngine;
using UnityEngine.UI;

public class AchievmentShow : MonoBehaviour
{
    public Text Achievementtext;
    public GameObject ob;

    public void Awake(){
        if (ob.name == "Deaths"){
            Achievementtext.text = "Deaths: " + Achievementmanager.Deaths.ToString("0");
        }
        if (ob.name == "Spike"){
            Achievementtext.text = "Death By Spike: " + Achievementmanager.DeathBySpike.ToString("0");
        }
        if (ob.name == "Cube"){
            Achievementtext.text = "Death By Cube: " + Achievementmanager.DeathByCube.ToString("0");
        }
        if (ob.name == "Void"){
            Achievementtext.text = "Death By Void: " + Achievementmanager.DeathByVoid.ToString("0");
        }
        if (ob.name == "Jump"){
            Achievementtext.text = "Jumps:" + Achievementmanager.Jumps.ToString("0");
        }
    }
}
