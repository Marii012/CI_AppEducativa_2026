using UnityEngine;

public class CardIdle : MonoBehaviour
{
    public float floatAmount = 3f;
    public float floatSpeed = 1f;
    public float rotateAmount = 1.5f;
    public float rotateSpeed = 1f;
    public float startDelay = 1f;

    private Vector3 startPos;
    private Quaternion startRot;
    private bool canAnimate = false;

    void Start()
    {
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
    }
}