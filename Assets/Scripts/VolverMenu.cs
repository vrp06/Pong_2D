using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    // Nombre de la escena del menú principal
    public string escenaMenu = "MainMenu";

    // Función que se llamará desde un botón
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene(escenaMenu);
    }
}