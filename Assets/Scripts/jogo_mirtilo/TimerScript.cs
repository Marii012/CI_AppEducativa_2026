using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private TMP_Text timerText;
    private float currentTimer;
    private bool isCounting;

    void Start()
    {
        timerText = GetComponent<TMP_Text>();
        currentTimer = 0f;
        isCounting = true;
    }

    void Update()
    {
        if (!isCounting) return;

        currentTimer += Time.deltaTime;

        int totalSeconds = Mathf.FloorToInt(currentTimer);
        timerText.text = totalSeconds.ToString("00");
    }

    public int GetTimerAndStop()
    {
        isCounting = false;
        return Mathf.FloorToInt(currentTimer);
    }
}