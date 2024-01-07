
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSave : MonoBehaviour
{
    private static LevelSave instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Debug.Log("huh");
        instance = this;
        DontDestroyOnLoad(gameObject);
        if (ImportantVariables.SaveExist == false){    // checks if save has loaded before
            ImportantVariables.SaveExist = true;
            
            SaveLoad.Load();
            ImportantVariables.SaveExist = true;
            SaveLoad.Save();
            Debug.Log("saved!");
        }
        
    }

    // Update is called once per frame
    private void OnApplicationQuit()
    {
        SaveLoad.Save(); // Call your save method here
    }
}
