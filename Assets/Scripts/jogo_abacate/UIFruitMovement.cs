using UnityEngine;

public class UIFruitMovement : MonoBehaviour
{
    public Vector2 velocidade;
    private RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        rt.anchoredPosition += velocidade * Time.deltaTime;

        if (rt.anchoredPosition.y < -800)
        {
            Destroy(gameObject);
        }
    }
}
