using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour
{
    [System.Serializable]
    public class FruitSetup
    {
        public GameObject prefab;
        public GameObject painel;
        public FruitClick.FoodType type;
    }

    [Header("Frutas e painéis")]
    public FruitSetup[] frutas;

    public RectTransform canvas;

    [Header("Spawn settings")]
    public float intervaloSpawn = 1f;
    public float startDelay = 2f;
    public float areaX = 300f;
    public float alturaSpawn = -400f;

    [Header("Velocidade das frutas")]
    public Vector2 velocidadeX = new Vector2(-150f, 150f);
    public Vector2 velocidadeY = new Vector2(-900f, -500f);

    private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            if (canSpawn)
                SpawnFruit();

            yield return new WaitForSeconds(intervaloSpawn);
        }
    }

    void SpawnFruit()
    {
        if (frutas == null || frutas.Length == 0 || canvas == null)
            return;

        int index = Random.Range(0, frutas.Length);

        GameObject fruit = Instantiate(frutas[index].prefab, canvas);
        fruit.transform.SetParent(canvas, false);

        RectTransform rt = fruit.GetComponent<RectTransform>();

        rt.anchoredPosition = new Vector2(
            Random.Range(-areaX, areaX),
            alturaSpawn
        );

        UIFruitMovement mover = fruit.GetComponent<UIFruitMovement>();
        if (mover == null)
            mover = fruit.AddComponent<UIFruitMovement>();

        mover.velocidade = new Vector2(
            Random.Range(velocidadeX.x, velocidadeX.y),
            Random.Range(velocidadeY.x, velocidadeY.y)
        );

        FruitClick click = fruit.GetComponent<FruitClick>();
        if (click == null)
            click = fruit.AddComponent<FruitClick>();

        click.foodType = frutas[index].type;
        click.Init(frutas[index].painel);
    }

    public void PauseSpawning()
    {
        canSpawn = false;
    }

    public void ResumeSpawning()
    {
        canSpawn = true;
    }
}