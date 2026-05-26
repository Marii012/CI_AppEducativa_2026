using UnityEngine;
using System.Collections;

public class MirtiloPiscar : MonoBehaviour
{
    [Header("Referências")]
    public GameObject olhosAbertos;
    public GameObject olhosFechados;

    [Header("Configurações do Piscar")]
    public float intervaloMin = 2f;
    public float intervaloMax = 5f;
    public float duracaoPiscar = 0.15f;

    void Start()
    {
        olhosAbertos.SetActive(true);
        olhosFechados.SetActive(false);

        StartCoroutine(PiscarCoroutine());
    }

    IEnumerator PiscarCoroutine()
    {
        while (true)
        {
            float wait = Random.Range(intervaloMin, intervaloMax);
            yield return new WaitForSeconds(wait);

            // fechar olhos
            olhosAbertos.SetActive(false);
            olhosFechados.SetActive(true);

            yield return new WaitForSeconds(duracaoPiscar);

            // abrir olhos
            olhosAbertos.SetActive(true);
            olhosFechados.SetActive(false);
        }
    }
}