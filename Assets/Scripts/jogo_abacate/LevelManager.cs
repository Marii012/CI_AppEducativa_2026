using UnityEngine;

public static class LevelManager
{
    public static int currentLevel = 1;

    public static int GetTargetScore()
    {
        switch (currentLevel)
        {
            case 1: return 20;
            case 2: return 30;
            case 3: return 40;
            default: return 50;
        }
    }

    public static void NextLevel()
    {
        currentLevel++;
    }

    public static void Reset()
    {
        currentLevel = 1;
    }
}