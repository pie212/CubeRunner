using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImportantVariables 
{
   public static int Money = 40;
   public static int skin;                 // plskin
   public static List<int> SkinsList = new List<int>();
   public static List<int> LevelAllowed = new List<int>();





   // settings
   public static float MobileSensitivity = 1F;
   public static float MenuMusicVol = 1.0F;
//   public static float 

   // graphics
   public static bool MotionBlur = true;
   public static bool Bloom = true;
   
   // abilitys
   public static int AbilityNumb =0;
   public static List<int> AbilityList = new List<int>();

   public static bool Explosive = false;           // the version where there are forces interacting with the explosions, the explosion force
   public static float Explosionforce = 500f;
   public static float Explosionrange = 1.0f;
}
