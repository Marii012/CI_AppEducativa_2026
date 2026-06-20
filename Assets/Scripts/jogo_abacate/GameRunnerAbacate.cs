using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameRunnerAbacate : MonoBehaviour
{
    [SerializeField] private float matchTimer = 30f;
    [SerializeField] private TMP_Text timerText;

    [Header("Scenes")]
    [SerializeField] private string winScene = "Jogo_Abacate_NivelCompleto";
    [SerializeField] private string loseScene = "Jogo_Abacate_NivelIncompleto";
    [SerializeField] private string finalScene = "Jogo_Abacate_Fim";

    [Header("Level")]
    [SerializeField] private int levelIndex = 1;

    private float currentTime = 0f;
    private bool isPaused = false;

    void Start()
    {
        currentTime = 0f;
        GameManagerAbacate.Reset();
    }

    void Update()
    {
        if (isPaused) return;

        currentTime += Time.deltaTime;

        float remaining = matchTimer - currentTime;

        if (remaining <= 0f)
        {
            HandleEndGame();
            return;
        }

        if (timerText != null)
        {
            remaining = Mathf.Max(0f, remaining);
            timerText.text = Mathf.CeilToInt(remaining).ToString("00");
        }
    }

    void HandleEndGame()
    {
        if (timerText != null)
            timerText.text = "00";

        int score = GameManagerAbacate.GetScore();
        int target = LevelManager.GetTargetScore();

        // PERDEU
        if (score < target)
        {
            SceneManager.LoadScene(loseScene);
            return;
        }

        // GANHOU
        if (levelIndex == 3)
            SceneManager.LoadScene(finalScene);
        else
            SceneManager.LoadScene(winScene);
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }
}