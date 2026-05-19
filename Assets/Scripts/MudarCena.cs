using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoMudarCena : MonoBehaviour
{
    public string nomeCena; // digite aqui o nome da cena que quer abrir

    // Método para chamar no botão
    public void MudarCena()
    {
        if (!string.IsNullOrEmpty(nomeCena))
        {
            SceneManager.LoadScene(nomeCena);
        }
    }
}