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
    private bool alreadyClicked = false; // 🚫 bloqueia spam

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
        // 🚫 só permite 1 clique por fruta
        if (alreadyClicked) return;
        alreadyClicked = true;

        // 🎯 SCORE SYSTEM (apenas 1 vez)
        if (foodType == FoodType.Healthy)
            GameManagerAbacate.AddPoint();
        else
            GameManagerAbacate.RemovePoint();

        // 📌 painel só abre 1 vez por fruta
        if (painelInfo != null && !paineisAbertos.Contains(painelInfo))
        {
            paineisAbertos.Add(painelInfo);
            painelInfo.SetActive(true);

            // ⏸ pausa spawn
            FruitSpawner spawner = FindFirstObjectByType<FruitSpawner>();
            if (spawner != null)
                spawner.PauseSpawning();

            // ⏸ pausa timer
            GameRunnerAbacate runner = FindFirstObjectByType<GameRunnerAbacate>();
            if (runner != null)
                runner.PauseTimer();
        }
    }
}