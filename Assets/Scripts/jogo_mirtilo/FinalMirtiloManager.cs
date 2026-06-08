using UnityEngine;
using TMPro;

public class FinalMirtiloManager : MonoBehaviour
{
    public TMP_Text tempoTotalText;

    void Start()
    {
        int tempo = GameManager.GetSeconds();
        Debug.Log("TEMPO RECEBIDO NA CENA FINAL: " + tempo);

        if (tempoTotalText != null)
        {
            tempoTotalText.text = "Tempo total: " + tempo.ToString("00") + "s";
        }
        else
        {
            Debug.LogError("O texto Tempo Total não está associado no FinalMirtiloManager.");
        }
    }
}