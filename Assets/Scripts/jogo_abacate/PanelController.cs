using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject painel;
    public FruitSpawner spawner;

    private GameRunnerAbacate runner;

    void Awake()
    {
        runner = FindFirstObjectByType<GameRunnerAbacate>();
    }

    public void OpenPanel()
    {
        painel.SetActive(true);

        Debug.Log("OPEN PANEL");

        spawner?.PauseSpawning();

        if (runner != null)
        {
            Debug.Log("PAUSAR TIMER");
            runner.PauseTimer();
        }
        else
        {
            Debug.LogError("RUNNER NÃO ENCONTRADO");
        }
    }

    public void ClosePanel()
    {
        painel.SetActive(false);

        Debug.Log("CLOSE PANEL");

        spawner?.ResumeSpawning();

        if (runner != null)
        {
            Debug.Log("RETOMAR TIMER");
            runner.ResumeTimer();
        }
        else
        {
            Debug.LogError("RUNNER NÃO ENCONTRADO");
        }
    }
}