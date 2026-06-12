using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    void Start()
    {
        Time.timeScale = 1f;

        if (scoreText != null)
            scoreText.text = GameManagerAbacate.GetScore().ToString();
    }

    public void TryAgain()
    {
        GameManagerAbacate.Reset();
        SceneManager.LoadScene("NomeDaCenaDoNivel");
    }
}