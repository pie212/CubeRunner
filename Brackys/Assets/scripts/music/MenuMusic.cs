
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Shop" || sceneName == "Menu" || sceneName == "LevelSelect")
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
