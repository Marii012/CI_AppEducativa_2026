using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    void Update()
    {
        scoreText.text = GameManagerAbacate.GetScore().ToString();
    }
}