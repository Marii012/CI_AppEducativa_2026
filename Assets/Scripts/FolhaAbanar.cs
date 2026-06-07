using UnityEngine;

public class LeafSway : MonoBehaviour
{
    public float swayAmount = 3f;   // intensidade (graus)
    public float swaySpeed = 1.5f;  // velocidade do vento

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

        transform.localRotation = startRotation * Quaternion.Euler(0f, 0f, sway);
    }
}