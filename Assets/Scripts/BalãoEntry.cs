using UnityEngine;

public class HeroEntrySubtle : MonoBehaviour
{
    public float breatheStrength = 0.03f;   // escala muito subtil
    public float breatheSpeed = 2f;

    public float wobbleStrength = 1.2f;     // rotação leve
    public float wobbleSpeed = 1.5f;

    private Vector3 originalScale;
    private Quaternion originalRot;

    void Start()
    {
        originalScale = transform.localScale;
        originalRot = transform.rotation;
    }

    void Update()
    {
        // “breathing” estilo balão vivo
        float breathe = 1f + Mathf.Sin(Time.time * breatheSpeed) * breatheStrength;

        transform.localScale = originalScale * breathe;

        // wobble tipo comic speech bubble
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleStrength;

        transform.rotation = originalRot * Quaternion.Euler(0f, 0f, wobble);
    }
}