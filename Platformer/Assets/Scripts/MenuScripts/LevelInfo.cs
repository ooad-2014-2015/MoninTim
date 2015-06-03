using UnityEngine;
using System.Collections;

public struct LevelStruct
{
    public string[] levelarray;
    public int numberOfCoins;
}

// Singleton klasa
public class LevelInfo : MonoBehaviour {
    
    private static LevelInfo _instance = null;
    
    public static LevelInfo Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public static int nextLevel = 1;
    private static LevelStruct customLevel;
    public static bool isCustomLevel = false;

    public static LevelStruct GetLevel(int index)
    {
        if (isCustomLevel)
            return customLevel;
        else if (index == 5) // koliko ima levela
            Application.LoadLevel("MenuScene");

        LevelStruct level1 = new LevelStruct();
        level1.levelarray = new string[] { "WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW",
                                            "W                                      W",
                                            "W                                      W",
                                            "W      C                               W",
                                            "W                     C                W",
                                            "W                         WWWWWW       W",
                                            "W             WWW           |          W",
                                            "W            XXXXX                     W",
                                            "W             WWW                      W",
                                            "W                                      W",
                                            "W      -   W  P                        W",
                                            "W                                   C  W",
                                            "W                                      W",
                                            "W                                      W",
                                            "W                                      W" };
        level1.numberOfCoins = 3;

        LevelStruct level2 = new LevelStruct();
        level2.levelarray = new string[] {  "W                                      W",
                                            "W                                      W",
                                            "W                                      W",
                                            "W                                      W",
                                            "W       X                              W",
                                            "W   C   X      W                       W",
                                            "W       X                              W",
                                            "W       X  C                           W",
                                            "W   C   X   -       W                  W",
                                            "W       X                              W",
                                            "W       X                      P       W",
                                            "W   C         WWWWWWWWWWWWW         C  W",
                                            "W                                      W",
                                            "W                                      W",
                                            "W                                      W" };
        level2.numberOfCoins = 5;

        LevelStruct level3 = new LevelStruct();
        level3.levelarray = new string[] {  "                                        ",
                                            "                                        ",
                                            "                                        ",
                                            "     C          W               C       ",
                                            "                                        ",
                                            "                                        ",
                                            "             C                XXXXXXX   ",
                                            "         W   -         W                ",
                                            "                       |                ",
                                            "                              P         ",
                                            "                  W                     ",
                                            "                                        ",
                                            "                                        ",
                                            "                                        " };
        level3.numberOfCoins = 3;

        LevelStruct level4 = new LevelStruct();
        level4.levelarray = new string[] {  "              C                         ",
                                            "W                                       ",
                                            "|              W                        ",
                                            "               W                        ",
                                            "               W                        ",
                                            "             C W                        ",
                                            "               W    XXXXXXXXXXXXXXXX    ",
                                            "W   -        WWW                        ",
                                            "               W                        ",
                                            "        P      W C                      ",
                                            "    W          W                        ",
                                            "               W                        ",
                                            "              W                        ",
                                            "                XXXXXXXXXXXX            ",
                                            "                                        " };
        level4.numberOfCoins = 3;

        LevelStruct level5 = new LevelStruct();
        level5.levelarray = new string[] {  "                                        ",
                                            "                 C                C     ",
                                            "                                        ",
                                            "    C                                   ",
                                            "          W      W       W        W     ",
                                            "                                        ",
                                            "                                        ",
                                            "W         C               C             ",
                                            "                                  P     ",
                                            "                                        ",
                                            "  W       W       W       W       W     ",
                                            "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                                            "                                        ",
                                            "                                        ",
                                            "                                        " };
        level5.numberOfCoins = 5;

        System.Collections.Generic.List<LevelStruct> levels = new System.Collections.Generic.List<LevelStruct>();
        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);
        levels.Add(level4);
        levels.Add(level5);
        
        return levels[index - 1];
    }

    public static void SetCustomLevel(string[] arr, int coins)
    {
        isCustomLevel = true;
        customLevel.levelarray = arr;
        customLevel.numberOfCoins = coins;
    }
}
