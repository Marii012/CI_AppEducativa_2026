using UnityEngine;

public static class GameManagerAbacate
{
    private static int score = 0;

    public static void AddPoint()
    {
        score++;
    }

    public static void RemovePoint()
    {
        score = Mathf.Max(0, score - 1);
    }

    public static int GetScore()
    {
        return score;
    }

    public static void Reset()
    {
        score = 0;
    }
}