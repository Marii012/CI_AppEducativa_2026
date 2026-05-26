using UnityEngine;
using UnityEngine.UI;

public class StarBlink : MonoBehaviour
{
    public float blinkSpeed = 2f;
    public float minAlpha = 0.2f;
    public float maxAlpha = 1f;
    public float scaleAmount = 0.15f;

    private Image image;
    private Vector3 startScale;

    void Start()
    {
        image = GetComponent<Image>();
        startScale = transform.localScale;
    }

    void Update()
    {
        if (image == null) return;

        float wave = (Mathf.Sin(Time.time * blinkSpeed) + 1f) / 2f;

        Color color = image.color;
        color.a = Mathf.Lerp(minAlpha, maxAlpha, wave);
        image.color = color;

        float scale = 1f + (wave * scaleAmount);
        transform.localScale = startScale * scale;
    }
}