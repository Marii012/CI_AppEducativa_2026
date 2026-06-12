using UnityEngine;

public class BalloonFly : MonoBehaviour
{
    [Header("Up Movement")]
    public float riseSpeed = 4f;   // ⬆️ mais rápido

    [Header("Side Movement (wind)")]
    public float swayAmount = 0.3f; // leve
    public float swaySpeed = 1.5f;

    [Header("Scale")]
    public float startScale = 0.4f;
    public float maxScale = 1f;

    [Header("Destroy")]
    public float destroyY = 12f;

    private Vector3 startPos;
    private float offset;

    void Start()
    {
        startPos = transform.position;
        offset = Random.Range(0f, 100f);

        transform.localScale = Vector3.one * startScale;
    }

    void Update()
    {
        // 🎈 subida mais rápida
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;

        // 🌬️ esvoaçar suave para os lados
        float sway = Mathf.Sin((Time.time + offset) * swaySpeed) * swayAmount;
        transform.position = new Vector3(startPos.x + sway, transform.position.y, transform.position.z);

        // 📈 cresce ligeiramente enquanto sobe
        float t = Mathf.Clamp01((transform.position.y - startPos.y) / destroyY);
        transform.localScale = Vector3.one * Mathf.Lerp(startScale, maxScale, t);

        // 🗑️ destruir ao sair do ecrã
        if (transform.position.y > destroyY)
        {
            Destroy(gameObject);
        }
    }
}