using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FruitClick : MonoBehaviour
{
    public enum FoodType
    {
        Healthy,
        Unhealthy
    }

    public FoodType foodType;
    public GameObject painelInfo;

    private Button button;

    private static HashSet<GameObject> paineisAbertos = new HashSet<GameObject>();

    public void Init(GameObject painel)
    {
        painelInfo = painel;

        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnFruitClicked);
        }
    }

    void OnFruitClicked()
    {
        // 🎯 SCORE SYSTEM
        if (foodType == FoodType.Healthy)
            GameManagerAbacate.AddPoint();
        else
            GameManagerAbacate.RemovePoint();

        if (painelInfo == null)
            return;

        if (paineisAbertos.Contains(painelInfo))
            return;

        paineisAbertos.Add(painelInfo);

        painelInfo.SetActive(true);

        // ⏸ pausa spawn
        FruitSpawner spawner = FindFirstObjectByType<FruitSpawner>();
        if (spawner != null)
            spawner.PauseSpawning();

        // ⏸ pausa timer (ISTO FALTAVA)
        GameRunnerAbacate runner = FindFirstObjectByType<GameRunnerAbacate>();
        if (runner != null)
            runner.PauseTimer();
    }
}