using UnityEngine;

public class CardEntrance : MonoBehaviour
{
    public float speed = 5f;
    public float delay = 0f;
    public float startOffsetY = -350f;

    private Vector3 targetPosition;
    private float timer = 0f;

    void Start()
    {
        targetPosition = transform.localPosition;
        transform.localPosition = targetPosition + new Vector3(0, startOffsetY, 0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                targetPosition,
                Time.deltaTime * speed
            );
        }
    }
}