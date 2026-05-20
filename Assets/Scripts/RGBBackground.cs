using UnityEngine;
using UnityEngine.UI;

public class RGBLayeredBackground : MonoBehaviour
{
    [Header("Layers")]
    public Image redLayer;
    public Image greenLayer;
    public Image blueLayer;

    public float speed = 1.5f;

    [Header("Red Colors")]
    public Color redA = new Color(1f, 0.2f, 0.2f);
    public Color redB = new Color(0.6f, 0f, 0f);

    [Header("Green Colors")]
    public Color greenA = new Color(0.2f, 1f, 0.2f);
    public Color greenB = new Color(0f, 0.4f, 0f);

    [Header("Blue Colors")]
    public Color blueA = new Color(0.2f, 0.4f, 1f);
    public Color blueB = new Color(0f, 0f, 0.6f);

    private float t;

    void Update()
    {
        t += Time.deltaTime * speed;

        float rWave = Mathf.Sin(t) * 0.5f + 0.5f;
        float gWave = Mathf.Sin(t + 2f) * 0.5f + 0.5f;
        float bWave = Mathf.Sin(t + 4f) * 0.5f + 0.5f;

        if (redLayer != null)
            redLayer.color = Color.Lerp(redA, redB, rWave);

        if (greenLayer != null)
            greenLayer.color = Color.Lerp(greenA, greenB, gWave);

        if (blueLayer != null)
            blueLayer.color = Color.Lerp(blueA, blueB, bWave);
    }
}