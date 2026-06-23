using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CardsManager : MonoBehaviour
{
    [Header("Cartas do jogo")]
    [SerializeField] private List<CardScript> listOfCards;

    [Header("Imagens dos pares")]
    [SerializeField] private List<Sprite> sprites;

    [Header("Elementos do jogo")]
    [SerializeField] private AudioSource victoryMusic;
    [SerializeField] private TimerScript timerScript;
    [SerializeField] private string finalSceneName = "missao_completa_jogo_mirtilo";

    private CardScript firstSelectedItem;
    private CardScript secondSelectedItem;

    private int numberOfMatches = 0;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponentInParent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("Falta o CanvasGroup no Canvas.");
            return;
        }

        if (listOfCards.Count / 2 != sprites.Count)
        {
            Debug.LogError("Configuração errada: tens de ter metade dos sprites em relação ao número de cartas. Ex: 6 cartas = 3 sprites.");
            return;
        }

        for (int i = 0; i < listOfCards.Count; i++)
        {
            listOfCards[i].EnableCover();
            listOfCards[i].SetBelowImage(sprites[i / 2]);
        }

        Shuffle(listOfCards);
    }

    void Shuffle<T>(List<T> list)
    {
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }

        for (int i = 0; i < listOfCards.Count; i++)
        {
            listOfCards[i].transform.SetSiblingIndex(i);
        }
    }

    public void OnCardClick()
    {
        if (EventSystem.current.currentSelectedGameObject == null) return;

        if (firstSelectedItem != null && secondSelectedItem != null) return;

        CardScript clickedItem = EventSystem.current.currentSelectedGameObject.GetComponentInParent<CardScript>();

        if (clickedItem == null) return;

        if (clickedItem == firstSelectedItem) return;

        if (firstSelectedItem == null)
        {
            firstSelectedItem = clickedItem;
            firstSelectedItem.DisableCover();
        }
        else
        {
            secondSelectedItem = clickedItem;
            secondSelectedItem.DisableCover();
            CompareChosenItems();
        }
    }

    private void CompareChosenItems()
    {
        if (firstSelectedItem.Below.sprite == secondSelectedItem.Below.sprite)
        {
            numberOfMatches++;
            StartCoroutine(ResetAndCheckFinish(0.4f, false));
        }
        else
        {
            StartCoroutine(ResetAndCheckFinish(1.2f, true));
        }
    }

    IEnumerator ResetAndCheckFinish(float secondsToWait, bool shouldReset)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        yield return new WaitForSeconds(secondsToWait);

        if (shouldReset)
        {
            firstSelectedItem.EnableCover();
            secondSelectedItem.EnableCover();
        }

        firstSelectedItem = null;
        secondSelectedItem = null;

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        if (numberOfMatches == listOfCards.Count / 2)
        {
            StartCoroutine(LoadFinalScene());
        }
    }

    IEnumerator LoadFinalScene()
    {
        if (timerScript != null)
        {
            int tempoFinal = timerScript.GetTimerAndStop();
            GameManager.SetSeconds(tempoFinal);
            Debug.Log("TEMPO GUARDADO: " + tempoFinal);
        }

        if (victoryMusic != null && victoryMusic.clip != null)
        {
            victoryMusic.Play();
            yield return new WaitForSeconds(victoryMusic.clip.length);
        }

        SceneManager.LoadScene(finalSceneName);
    }
}