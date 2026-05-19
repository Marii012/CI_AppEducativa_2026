using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // mantém entre cenas
            GetComponent<AudioSource>().Play(); // garante que toca se não estiver tocando
        }
        else
        {
            Destroy(gameObject); // previne duplicados
        }
    }
}