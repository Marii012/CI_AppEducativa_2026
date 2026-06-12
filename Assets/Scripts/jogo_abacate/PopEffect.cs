using UnityEngine;
using System.Collections;

public class PopEffect : MonoBehaviour
{
    [Header("Pop Settings")]
    public float popScale = 1.5f;
    public float duration = 0.2f;

    [Header("Delay antes de aparecer")]
    public float startDelay = 0f;

    private Vector3 originalScale;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        originalScale = transform.localScale;

        // tenta pegar CanvasGroup (UI)
        canvasGroup = GetComponent<CanvasGroup>();

        // se não tiver, adiciona automaticamente
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        // começa invisível
        canvasGroup.alpha = 0f;
    }

    void OnEnable()
    {
        StartCoroutine(PopRoutine());
    }

    IEnumerator PopRoutine()
    {
        // ⏳ espera antes de aparecer
        if (startDelay > 0f)
            yield return new WaitForSeconds(startDelay);

        // aparece
        canvasGroup.alpha = 1f;

        // começa grande
        transform.localScale = originalScale * popScale;

        float time = 0f;

        // animação pop
        while (time < duration)
        {
            time += Time.deltaTime;

            transform.localScale = Vector3.Lerp(
                originalScale * popScale,
                originalScale,
                time / duration
            );

            yield return null;
        }

        transform.localScale = originalScale;
    }
}