using UnityEngine;

public class MustacheWiggle : MonoBehaviour
{
    public float rotateAmount = 4f;
    public float speed = 2f;

    Quaternion startRot;

    void Start()
    {
        startRot = transform.localRotation;
    }

    void Update()
    {
        float rot = Mathf.Sin(Time.time * speed) * rotateAmount;
        transform.localRotation = startRot * Quaternion.Euler(0,0,rot);
    }
}