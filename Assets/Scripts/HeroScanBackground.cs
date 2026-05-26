using UnityEngine;
using UnityEngine.UI;

public class HeroScanBackground : MonoBehaviour
{
    [Header("Layers")]
    public Image redLayer;
    public Image greenLayer;
    public Image blueLayer;

    [Header("Scan Settings")]
    public float speed = 1f;
    public float intensity = 0.25f;   // força do brilho
    public float baseAlpha = 0.6f;    // opacidade base

    private float t;

    void Update()
    {
        t += Time.deltaTime * speed;

        ApplyScan(redLayer, t);
        ApplyScan(greenLayer, t + 2f);
        ApplyScan(blueLayer, t + 4f);
    }

    void ApplyScan(Image img, float time)
    {
        if (!img) return;

        // cria onda suave tipo "linha a passar"
        float wave = Mathf.Sin(time) * 0.5f + 0.5f;

        // deixa a variação mais focada (efeito de “passagem de linha”)
        float scan = Mathf.Pow(wave, 6f);

        float alpha = baseAlpha + scan * intensity;

        Color c = img.color;
        c.a = Mathf.Clamp01(alpha);
        img.color = c;
    }
}