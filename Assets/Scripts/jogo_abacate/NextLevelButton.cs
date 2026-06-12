using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Jogo_Abacate_Nivel2";

    public void GoNextLevel()
    {
        LevelManager.NextLevel();
        SceneManager.LoadScene(nextSceneName);
    }
}