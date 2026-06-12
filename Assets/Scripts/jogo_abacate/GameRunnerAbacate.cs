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

    private float currentTime = 0f;
    private bool isPaused = false;

    void Start()
    {
        currentTime = 0f;
        GameManagerAbacate.Reset();
    }

    void Update()
    {
        if (isPaused)
            return;

        currentTime += Time.deltaTime;

        float remaining = matchTimer - currentTime;

        if (remaining <= 0f)
        {
            timerText.text = "00";

            int score = GameManagerAbacate.GetScore();
            int target = LevelManager.GetTargetScore();

            if (score >= target)
                SceneManager.LoadScene(winScene);
            else
                SceneManager.LoadScene(loseScene);

            return;
        }

        if (timerText != null)
        {
            remaining = Mathf.Max(0f, remaining);
            timerText.text = Mathf.CeilToInt(remaining).ToString("00");
        }
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