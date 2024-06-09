using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveLoad 
{
    public static bool SaveExist;
    public static int Money;
    public static int skin;                 
    public static List<int> SkinsList = new List<int>();
    public static List<int> LevelAllowed = new List<int>();
    public static int PlayerDeaths;

    // settings
    public static float MobileSensitivity;
    public static float MenuMusicVol;
    public static bool MouseVisible;
   
    // graphics
    public static bool MotionBlur;
    public static bool Bloom;
   
    // abilities
    public static int AbilityNumb;
    public static List<int> AbilityList = new List<int>();

    public static bool Explosive;
    public static float Explosionforce;
    public static float Explosionrange;

    public static void Save()
    {
        SaveData saveData = new SaveData()
        {
            SaveExist = ImportantVariables.SaveExist,
            Money = ImportantVariables.Money,
            skin = ImportantVariables.skin,
            SkinsList = ImportantVariables.SkinsList,
            LevelAllowed = ImportantVariables.LevelAllowed,
            PlayerDeaths = ImportantVariables.PlayerDeaths,
            MobileSensitivity = ImportantVariables.MobileSensitivity,
            MenuMusicVol = ImportantVariables.MenuMusicVol,
            MouseVisible = ImportantVariables.MouseVisible,
            MotionBlur = ImportantVariables.MotionBlur,
            Bloom = ImportantVariables.Bloom,
            AbilityNumb = ImportantVariables.AbilityNumb,
            AbilityList = ImportantVariables.AbilityList,
            Explosive = ImportantVariables.Explosive,
            Explosionforce = ImportantVariables.Explosionforce,
            Explosionrange = ImportantVariables.Explosionrange
        };

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText("savefile.json", json);
        Debug.Log("Variables saved!");
    }

    public static void Load()
    {
        if (File.Exists("savefile.json"))
        {
            string json = File.ReadAllText("savefile.json");
            SaveData savedData = JsonUtility.FromJson<SaveData>(json);

            ImportantVariables.SaveExist = savedData.SaveExist;
            ImportantVariables.Money = savedData.Money;
            ImportantVariables.skin = savedData.skin;
            ImportantVariables.SkinsList = savedData.SkinsList;
            ImportantVariables.LevelAllowed = savedData.LevelAllowed;
            ImportantVariables.PlayerDeaths = savedData.PlayerDeaths;
            ImportantVariables.MobileSensitivity = savedData.MobileSensitivity;
            ImportantVariables.MenuMusicVol = savedData.MenuMusicVol;
            ImportantVariables.MouseVisible = savedData.MouseVisible;
            ImportantVariables.MotionBlur = savedData.MotionBlur;
            ImportantVariables.Bloom = savedData.Bloom;
            ImportantVariables.AbilityNumb = savedData.AbilityNumb;
            ImportantVariables.AbilityList = savedData.AbilityList;
            ImportantVariables.Explosive = savedData.Explosive;
            ImportantVariables.Explosionforce = savedData.Explosionforce;
            ImportantVariables.Explosionrange = savedData.Explosionrange;

            Debug.Log("Variables loaded!");
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public bool SaveExist;
        public int Money;
        public int skin;
        public List<int> SkinsList;
        public List<int> LevelAllowed;
        public int PlayerDeaths;

        // settings
        public float MobileSensitivity;
        public float MenuMusicVol;
        public bool MouseVisible;

        // graphics
        public bool MotionBlur;
        public bool Bloom;

        // abilities
        public int AbilityNumb;
        public List<int> AbilityList;

        public bool Explosive;
        public float Explosionforce;
        public float Explosionrange;
    }
}
