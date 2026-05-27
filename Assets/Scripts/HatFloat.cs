using UnityEngine;

public class HatFloat : MonoBehaviour
{
    public float floatAmount = 3f;
    public float floatSpeed = 2f;

    public float rotateAmount = 6f;
    public float rotateSpeed = 1.5f;

    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        startPos = transform.localPosition;
        startRot = transform.localRotation;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        float rot = Mathf.Sin(Time.time * rotateSpeed) * rotateAmount;

        transform.localPosition = startPos + new Vector3(0, y, 0);
        transform.localRotation = startRot * Quaternion.Euler(0, 0, rot);
    }
}
