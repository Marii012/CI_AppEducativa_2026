using UnityEngine;
using TMPro;
using System.Collections;

public class CleanTypewriter : MonoBehaviour
{
    public TMP_Text text;
    [TextArea] public string fullText;

    public float startDelay = 0.8f;
    public float letterDelay = 0.05f;

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        text.text = fullText;
        text.maxVisibleCharacters = 0;

        yield return new WaitForSeconds(startDelay);

        int totalChars = fullText.Length;

        for (int i = 0; i <= totalChars; i++)
        {
            text.maxVisibleCharacters = i;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}