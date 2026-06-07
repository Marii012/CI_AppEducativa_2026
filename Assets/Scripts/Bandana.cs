using UnityEngine;
using UnityEngine.InputSystem;

public class BandanaMouseFollow : MonoBehaviour
{
    public float followStrength = 20f;
    public float smoothSpeed = 8f;

    private RectTransform rt;
    private Vector2 basePos;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        basePos = rt.anchoredPosition;
    }

    void Update()
    {
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