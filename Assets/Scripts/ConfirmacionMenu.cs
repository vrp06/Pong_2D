using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmacionMenu : MonoBehaviour
{
    public GameObject panelConfirmacion; // Panel de confirmación
    public string escenaMenu = "Menu";    // Nombre exacto de la escena del menú principal

    private void Start()
    {
        // Al iniciar el juego, ocultamos el panel
        if (panelConfirmacion != null)
            panelConfirmacion.SetActive(false);
    }

    // Se llama al pulsar el botón "Exit"
    public void MostrarPanel()
    {
        if (panelConfirmacion != null)
            panelConfirmacion.SetActive(true);
    }

    // Se llama al pulsar "Sí" para volver al menú
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene(escenaMenu);
    }

    // Se llama al pulsar "No" o "Volver al juego"
    public void CerrarPanel()
    {
        if (panelConfirmacion != null)
            panelConfirmacion.SetActive(false);
    }
}