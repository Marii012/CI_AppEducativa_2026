using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
public void GoNextLevel()
{
    if (LevelManager.currentLevel >= 3)
    {
        SceneManager.LoadScene("Jogo_Abacate_Fim");
        return;
    }

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
    }

    SceneManager.LoadScene(sceneName);
}
}