using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImportantVariables 
{
   public static int Money = 40;
   public static int skin = -1;                 // plskin
   public static List<int> SkinsList = new List<int>();
   public static List<int> LevelAllowed = new List<int>();
   public static int PlayerDeaths;



    // settings
    public static float MobileSensitivity = 1.0F;
   public static float MenuMusicVol = 1.0F;

   public static bool MouseVisible = true;
//   public static float 

   // graphics
   public static bool MotionBlur = true;
   public static bool Bloom = true;
   
   // abilitys
   public static int AbilityNumb =2;    // 0 = none, 1 = slowmo eagle eye, 2 = explosion, 3 = normal slowmo
   public static List<int> AbilityList = new List<int>();

   public static bool Explosive = false;           // the version where there are forces interacting with the explosions, the explosion force
   public static float Explosionforce = 500f;
   public static float Explosionrange = 1.0f;
}
