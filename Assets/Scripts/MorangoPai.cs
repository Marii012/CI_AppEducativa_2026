using UnityEngine;

public class FloatIdle : MonoBehaviour
{
    public float floatAmount = 0.05f;
    public float floatSpeed = 1.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * floatSpeed) * floatAmount;

        transform.localPosition = startPos + new Vector3(0, y, 0);
    }
}