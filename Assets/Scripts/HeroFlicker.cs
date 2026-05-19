using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroLightFlicker : MonoBehaviour
{
    public Image targetImage;

    [Header("Alpha Settings")]
    public float baseAlpha = 1f;     // intensidade normal
    public float minAlpha = 0.92f;   // nunca baixa muito
    public float maxAlpha = 1f;

    [Header("Timing")]
    public float minDelay = 0.05f;
    public float maxDelay = 0.25f;

    void Start()
    {
        if (targetImage == null)
            targetImage = GetComponent<Image>();

        StartCoroutine(FlickerLoop());
    }

    IEnumerator FlickerLoop()
    {
        while (true)
        {
            // tempo aleatório entre flickers (IMPORTANTE para não parecer mecânico)
            float wait = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(wait);

            // valor de flicker leve
            float alpha = Random.Range(minAlpha, maxAlpha);

            Color c = targetImage.color;
            c.a = alpha;
            targetImage.color = c;
        }
    }
}