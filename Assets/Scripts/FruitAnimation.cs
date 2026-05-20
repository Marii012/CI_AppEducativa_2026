using UnityEngine;

public class FruitAnimation : MonoBehaviour
{
    public float scaleSpeed = 2f;
    public float scaleAmount = 0.08f;
    public float rotateAmount = 4f;

    private Vector3 startScale;
    private Quaternion startRotation;

    void Start()
    {
        startScale = transform.localScale;
        startRotation = transform.localRotation;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
        float rotation = Mathf.Sin(Time.time * scaleSpeed) * rotateAmount;

        transform.localScale = startScale * scale;
        transform.localRotation = startRotation * Quaternion.Euler(0, 0, rotation);
    }
}
