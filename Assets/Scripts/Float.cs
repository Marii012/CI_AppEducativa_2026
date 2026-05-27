using UnityEngine;

public class BubbleDecorIdle : MonoBehaviour
{
    public float floatStrength = 0.03f;   // altura do “flutuar”
    public float floatSpeed = 1.1f;

    public float wobbleStrength = 1.5f;   // rotação leve
    public float wobbleSpeed = 0.9f;

    public float scalePulse = 0.01f;      // quase impercetível

    private Vector3 originalPos;
    private Vector3 originalScale;
    private Quaternion originalRot;

    private float randomOffset;

    void Start()
    {
        originalPos = transform.localPosition;
        originalScale = transform.localScale;
        originalRot = transform.localRotation;

        // dá variação entre objetos (evita tudo sincronizado)
        randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float t = Time.time + randomOffset;

        // float vertical suave
        float y = Mathf.Sin(t * floatSpeed) * floatStrength;

        // wobble leve tipo “vibração cartoon”
        float wobble = Mathf.Sin(t * wobbleSpeed) * wobbleStrength;

        // micro scale pulse
        float scale = 1f + Mathf.Sin(t * floatSpeed * 1.3f) * scalePulse;

        transform.localPosition = originalPos + new Vector3(0f, y, 0f);
        transform.localRotation = originalRot * Quaternion.Euler(0f, 0f, wobble);
        transform.localScale = originalScale * scale;
    }
}