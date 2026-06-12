using UnityEngine;

public class BalloonFlyV2 : MonoBehaviour
{
    [Header("Up Movement")]
    public float riseSpeed = 4f;

    [Header("Side Movement (wind)")]
    public float swayAmount = 0.3f;
    public float swaySpeed = 1.5f;

    [Header("Scale")]
    public float startScale = 0.4f;
    public float maxScale = 1f;

    [Header("Stop Settings")]
    public float stopY = 6f;
    public float stopSmoothness = 2f; // ⬅️ quanto mais alto, mais suave

    private Vector3 startPos;
    private float offset;

    private float currentSpeed;
    private bool slowingDown = false;

    void Start()
    {
        startPos = transform.position;
        offset = Random.Range(0f, 100f);

        currentSpeed = riseSpeed;

        transform.localScale = Vector3.one * startScale;
    }

    void Update()
    {
        // 🎈 começa a desacelerar perto do stopY
        if (transform.position.y >= stopY - 1f)
        {
            slowingDown = true;
        }

        if (!slowingDown)
        {
            currentSpeed = riseSpeed;
        }
        else
        {
            // 🌙 desaceleração suave
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * stopSmoothness);
        }

        // ⬆️ movimento vertical
        transform.position += Vector3.up * currentSpeed * Time.deltaTime;

        // 🌬️ vento lateral constante
        float sway = Mathf.Sin((Time.time + offset) * swaySpeed) * swayAmount;

        transform.position = new Vector3(
            startPos.x + sway,
            transform.position.y,
            transform.position.z
        );

        // 📈 escala enquanto sobe
        float t = Mathf.Clamp01((transform.position.y - startPos.y) / stopY);
        transform.localScale = Vector3.Lerp(
            Vector3.one * startScale,
            Vector3.one * maxScale,
            t
        );
    }
}