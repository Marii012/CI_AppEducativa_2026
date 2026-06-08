using UnityEngine;
using UnityEngine.EventSystems;

public class CardIdle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float floatAmount = 3f;
    public float floatSpeed = 1f;
    public float rotateAmount = 1.5f;
    public float rotateSpeed = 1f;
    public float startDelay = 1f;

    [Header("Hover")]
    public float hoverScale = 1.1f;
    public float hoverSpeed = 8f;

    private Vector3 startPos;
    private Quaternion startRot;
    private Vector3 originalScale;
    private Vector3 targetScale;

    private bool canAnimate = false;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;

        Invoke(nameof(StartIdle), startDelay);
    }

    void StartIdle()
    {
        startPos = transform.localPosition;
        startRot = transform.localRotation;
        canAnimate = true;
    }

    void Update()
    {
        if (!canAnimate) return;

        float y = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        float rot = Mathf.Sin(Time.time * rotateSpeed) * rotateAmount;

        transform.localPosition = startPos + new Vector3(0, y, 0);
        transform.localRotation = startRot * Quaternion.Euler(0, 0, rot);

        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * hoverSpeed
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = originalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale;
    }
}