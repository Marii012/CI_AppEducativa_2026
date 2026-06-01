using UnityEngine;
using UnityEngine.EventSystems;

public class HeroEntrySubtle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Idle Animation")]
    public float breatheStrength = 0.015f;
    public float breatheSpeed = 2f;

    public float wobbleStrength = 0.15f;
    public float wobbleSpeed = 1.2f;

    [Header("Entry Animation")]
    public float entryDuration = 0.6f;

    public float startScaleMultiplier = 0.9f;
    public float entryRotation = -3f;

    [Header("Hover")]
    public float hoverScale = 1.05f;
    public float hoverLift = 5f;
    public float hoverSpeed = 8f;

    private Vector3 originalScale;
    private Quaternion originalRot;
    private Vector3 originalPos;

    private float timer;
    private bool introFinished;

    private bool isHovered;

    void OnEnable()
    {
        originalScale = transform.localScale;
        originalRot = transform.rotation;
        originalPos = transform.localPosition;

        timer = 0f;
        introFinished = false;

        transform.localScale = originalScale * startScaleMultiplier;
        transform.rotation = originalRot * Quaternion.Euler(0f, 0f, entryRotation);
    }

    void Update()
    {
        if (!introFinished)
        {
            PlayEntry();
            return;
        }

        PlayIdleAndHover();
    }

    void PlayEntry()
    {
        timer += Time.deltaTime;

        float t = timer / entryDuration;

        if (t >= 1f)
        {
            t = 1f;
            introFinished = true;

            transform.localScale = originalScale;
            transform.rotation = originalRot;
            return;
        }

        float ease = 1f - Mathf.Pow(1f - t, 4f);

        transform.localScale = Vector3.Lerp(
            originalScale * startScaleMultiplier,
            originalScale,
            ease
        );

        float rot = Mathf.Lerp(entryRotation, 0f, ease);

        transform.rotation =
            originalRot *
            Quaternion.Euler(0f, 0f, rot);
    }

    void PlayIdleAndHover()
    {
        float breathe =
            1f + Mathf.Sin(Time.time * breatheSpeed) * breatheStrength;

        float wobble =
            Mathf.Sin(Time.time * wobbleSpeed) * wobbleStrength;

        Vector3 idleScale = originalScale * breathe;
        Quaternion idleRot = originalRot * Quaternion.Euler(0f, 0f, wobble);

        // 🎯 hover target
        float targetHover = isHovered ? 1f : 0f;

        float hoverLerp = Time.deltaTime * hoverSpeed;

        float scaleMultiplier = Mathf.Lerp(1f, hoverScale, targetHover);
        Vector3 hoverScaleVec = idleScale * scaleMultiplier;

        Vector3 hoverPos = originalPos + new Vector3(0f, isHovered ? hoverLift : 0f, 0f);

        transform.localScale = Vector3.Lerp(transform.localScale, hoverScaleVec, hoverLerp);
        transform.localPosition = Vector3.Lerp(transform.localPosition, hoverPos, hoverLerp);
        transform.rotation = Quaternion.Slerp(transform.rotation, idleRot, hoverLerp);
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