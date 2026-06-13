using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void GoNextLevel()
    {
        LevelManager.NextLevel();

        string sceneName = "";

        switch (LevelManager.currentLevel)
        {
            case 2:
                sceneName = "Jogo_Abacate_Nivel2";
                break;

            case 3:
                sceneName = "Jogo_Abacate_Nivel3";
                break;

            default:
                sceneName = "Jogo_Abacate_Fim";
                break;
        }

        SceneManager.LoadScene(sceneName);
    }
}