using UnityEngine;
using UnityEngine.EventSystems;

public class ComicHoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Entry")]
    public float startDelay = 0.8f;
    public float entryDuration = 0.7f;
    public float entryOffsetY = 120f;
    public float entryStartScale = 0.85f;

    [Header("Hover")]
    public float hoverScale = 1.05f;
    public float hoverTilt = 4f;
    public float hoverSpeed = 10f;

    [Header("Idle Motion (continuous)")]
    public float idleFloat = 2f;
    public float idleFloatSpeed = 1.5f;
    public float idleRotation = 1.5f;

    private Vector3 originalScale;
    private Vector3 originalPos;
    private Quaternion originalRot;

    private bool isHovered;

    private float delayTimer;
    private float entryTimer;

    private bool entryStarted;
    private bool entryDone;

    private float idleTime;

    void OnEnable()
    {
        originalScale = transform.localScale;
        originalPos = transform.localPosition;
        originalRot = transform.rotation;

        delayTimer = 0f;
        entryTimer = 0f;
        idleTime = 0f;

        entryStarted = false;
        entryDone = false;

        transform.localScale = originalScale * entryStartScale;
        transform.localPosition = originalPos - new Vector3(0f, entryOffsetY, 0f);
    }

    void Update()
    {
        if (!entryStarted)
        {
            HandleDelay();
            return;
        }

        if (!entryDone)
        {
            PlayEntry();
            return;
        }

        PlayHoverAndIdle();
    }

    void HandleDelay()
    {
        delayTimer += Time.deltaTime;

        if (delayTimer >= startDelay)
            entryStarted = true;
    }

    void PlayEntry()
    {
        entryTimer += Time.deltaTime;

        float t = entryTimer / entryDuration;

        if (t >= 1f)
        {
            t = 1f;
            entryDone = true;

            transform.localScale = originalScale;
            transform.localPosition = originalPos;
            transform.rotation = originalRot;
            return;
        }

        float ease = 1f - Mathf.Pow(1f - t, 4f);

        transform.localScale = Vector3.Lerp(
            originalScale * entryStartScale,
            originalScale,
            ease
        );

        transform.localPosition = Vector3.Lerp(
            originalPos - new Vector3(0f, entryOffsetY, 0f),
            originalPos,
            ease
        );
    }

    void PlayHoverAndIdle()
    {
        float lerp = Time.deltaTime * hoverSpeed;

        idleTime += Time.deltaTime;

        // 🌿 idle contínuo (respiração + leve flutuação)
        float floatY = Mathf.Sin(idleTime * idleFloatSpeed) * idleFloat;
        float rot = Mathf.Sin(idleTime * idleFloatSpeed * 0.8f) * idleRotation;

        Vector3 idlePos = originalPos + new Vector3(0f, floatY, 0f);
        Quaternion idleRot = originalRot * Quaternion.Euler(0f, 0f, rot);

        Vector3 targetScale = originalScale;

        if (isHovered)
        {
            targetScale = originalScale * hoverScale;
            idleRot = idleRot * Quaternion.Euler(0f, 0f, hoverTilt);
        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, lerp);
        transform.localPosition = Vector3.Lerp(transform.localPosition, idlePos, lerp);
        transform.rotation = Quaternion.Slerp(transform.rotation, idleRot, lerp);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (entryDone)
            isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}