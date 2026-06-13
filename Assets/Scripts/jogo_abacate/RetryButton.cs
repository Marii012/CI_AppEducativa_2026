using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void RetryLevel()
    {
        string sceneName = "Jogo_Abacate_Nivel" + LevelManager.currentLevel;
        SceneManager.LoadScene(sceneName);
    }
}