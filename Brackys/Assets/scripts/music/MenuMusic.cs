
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    public void Start(){
        GetComponent<AudioSource>().volume = ImportantVariables.MenuMusicVol;
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Shop" || sceneName == "Menu" || sceneName == "LevelSelect" || sceneName == "Stats"  || sceneName == "Settings" )
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Debug.Log("What the shit");
            Destroy(gameObject);
        }
    }
}
