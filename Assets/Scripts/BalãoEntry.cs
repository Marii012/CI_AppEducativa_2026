using System.Collections;
using UnityEngine;

public class HeroEntrySubtle : MonoBehaviour
{
    public float duration = 0.4f;
    public float smallPop = 0.05f; // MUITO leve

    private Vector3 originalScale;
    private Quaternion originalRot;

    void Start()
    {
        originalScale = transform.localScale;
        originalRot = transform.rotation;

        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float t = 0f;

        Vector3 slightlySmaller = originalScale * (1f - smallPop);

        while (t < 1f)
        {
            t += Time.deltaTime / duration;

            float ease = 1f - Mathf.Pow(1f - t, 3f); // ease out suave

            // só um micro "settle" de escala
            transform.localScale = Vector3.Lerp(slightlySmaller, originalScale, ease);

            // rotação quase inexistente (apenas estabiliza)
            transform.rotation = Quaternion.Slerp(
                originalRot * Quaternion.Euler(0f, 0f, 1.5f),
                originalRot,
                ease
            );

            yield return null;
        }

        transform.localScale = originalScale;
        transform.rotation = originalRot;
    }
}