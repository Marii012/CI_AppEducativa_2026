using UnityEngine;

public class CapeSwing : MonoBehaviour
{
    [Header("Rotação")]
    public float rotationAmount = 5f;
    public float rotationSpeed = 2f;

    [Header("Movimento")]
    public float moveAmount = 0.05f;
    public float moveSpeed = 1.5f;

    private Quaternion startRotation;
    private Vector3 startPosition;

    void Start()
    {
        startRotation = transform.localRotation;
        startPosition = transform.localPosition;
    }

    void Update()
    {
        // balanço suave
        float rotation = Mathf.Sin(Time.time * rotationSpeed) * rotationAmount;

        // pequeno movimento vertical
        float moveY = Mathf.Sin(Time.time * moveSpeed) * moveAmount;

        transform.localRotation = startRotation * Quaternion.Euler(0, 0, rotation);

        transform.localPosition = startPosition + new Vector3(0, moveY, 0);
    }
}