using UnityEngine;

public class RodaOscilar : MonoBehaviour
{
    public float amplitude = 5f;   // quantos graus vai para cada lado
    public float velocidade = 2f;  // rapidez do movimento

    float zInicial;

    void Start()
    {
        zInicial = transform.localRotation.eulerAngles.z;
    }

    void Update()
    {
        float angulo = Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.localRotation = Quaternion.Euler(0f, 0f, zInicial + angulo);
    }
}