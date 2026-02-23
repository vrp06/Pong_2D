using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void UnJugador()
    {
        GameManager.usarIA = true;
        SceneManager.LoadScene("GameScene");
    }

    public void DosJugadores()
    {
        GameManager.usarIA = false;
        SceneManager.LoadScene("GameScene");
    }
}