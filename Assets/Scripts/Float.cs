using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleDecorIdle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Idle")]
    public float floatStrength = 0.03f;
    public float floatSpeed = 1.1f;

    public float wobbleStrength = 1.5f;
    public float wobbleSpeed = 0.9f;

    public float scalePulse = 0.01f;

    [Header("Hover (subtil)")]
    public float hoverScale = 1.04f;
    public float hoverLift = 2f;
    public float hoverSpeed = 8f;

    private Vector3 originalPos;
    private Vector3 originalScale;
    private Quaternion originalRot;

    private float randomOffset;
    private bool isHovered;

    void Start()
    {
        originalPos = transform.localPosition;
        originalScale = transform.localScale;
        originalRot = transform.localRotation;

        randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float t = Time.time + randomOffset;

        // 🌿 idle base
        float y = Mathf.Sin(t * floatSpeed) * floatStrength;
        float wobble = Mathf.Sin(t * wobbleSpeed) * wobbleStrength;
        float scalePulseValue = 1f + Mathf.Sin(t * floatSpeed * 1.3f) * scalePulse;

        Vector3 idlePos = originalPos + new Vector3(0f, y, 0f);
        Quaternion idleRot = originalRot * Quaternion.Euler(0f, 0f, wobble);
        Vector3 idleScale = originalScale * scalePulseValue;

        // 🟡 hover target (muito leve)
        Vector3 hoverPos = originalPos + new Vector3(0f, hoverLift, 0f);
        Vector3 hoverScaleVec = originalScale * hoverScale;

        float lerp = Time.deltaTime * hoverSpeed;

        Vector3 targetPos = isHovered ? hoverPos : idlePos;
        Vector3 targetScale = isHovered ? hoverScaleVec : idleScale;
        Quaternion targetRot = idleRot;

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, lerp);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, lerp);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, lerp);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}