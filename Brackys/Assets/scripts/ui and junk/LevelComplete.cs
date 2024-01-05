
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class LevelComplete : MonoBehaviour
{
    
    public void LoadNextLevel(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        bool containsAllNumbers = Enumerable.Range(1, FindObjectOfType<EndTrigger>().NextLevel - 1).All(ImportantVariables.LevelAllowed.Contains);
        bool containsNextlevel = ImportantVariables.LevelAllowed.Contains(FindObjectOfType<EndTrigger>().NextLevel);
        if (containsAllNumbers || containsNextlevel)
        {
        SceneManager.LoadScene("Level " + FindObjectOfType<EndTrigger>().NextLevel.ToString("0"));
        }
        else{
        SceneManager.LoadScene("Level " + (FindObjectOfType<EndTrigger>().NextLevel-1).ToString("0"));
        }
}
}