using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class AvocadoMouseFollow : MonoBehaviour
{
    public float followStrength = 25f;
    public float smoothSpeed = 8f;

    public float entryDuration = 1.2f;
    public float entryDistance = 200f;

    private RectTransform rt;
    private Vector2 basePos;

    private bool canFollow = false;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        basePos = rt.anchoredPosition;

        // começa abaixo
        rt.anchoredPosition = basePos + Vector2.down * entryDistance;

        StartCoroutine(EntryAnimation());
    }

    IEnumerator EntryAnimation()
    {
        Vector2 start = rt.anchoredPosition;
        float t = 0f;

        while (t < entryDuration)
        {
            t += Time.deltaTime;
            float p = t / entryDuration;

            // easing suave tipo "hero entrance"
            float smooth = 1f - Mathf.Pow(1f - p, 3);

            rt.anchoredPosition = Vector2.Lerp(start, basePos, smooth);

            yield return null;
        }

        rt.anchoredPosition = basePos;
        canFollow = true;
    }

    void Update()
    {
        if (!canFollow) return;

        Vector2 mousePos = Mouse.current.position.ReadValue();

        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        Vector2 dir = (mousePos - screenCenter) / screenCenter;

        dir = Vector2.ClampMagnitude(dir, 1f);

        Vector2 targetOffset = dir * followStrength;

        rt.anchoredPosition = Vector2.Lerp(
            rt.anchoredPosition,
            basePos + targetOffset,
            Time.deltaTime * smoothSpeed
        );
    }
}