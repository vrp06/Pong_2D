using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject pilota;
    public TMP_Text marcadorText;
    public TMP_Text compteEnrereText;
    public GameObject panelFinal; // Panel que aparece al finalizar
    public RightPlayerIA rightPlayerIA; // Script IA del jugador derecho

    [Header("Configuración")]
    public int golesParaGanar = 5;
    public static bool usarIA = false;

    private int LeftScore = 0;
    private int RightScore = 0;
    private bool esperantTecla = false;
    private bool juegoTerminado = false;

    private void Start()
    {
        // Panel final oculto al iniciar
        if (panelFinal != null)
            panelFinal.SetActive(false);

        // Si hay IA, desactivamos el movimiento hasta que la pelota se lance
        if (usarIA && rightPlayerIA != null)
            rightPlayerIA.enabled = false;
    }

    // Función llamada desde Goal
    public void GolMarcat(float porteriaX)
    {
        if (juegoTerminado) return;

        string jugadorQueAnota;

        // Punt per jugador
        if (porteriaX < 0)
        {
            RightScore++;
            jugadorQueAnota = "Jugador Derecho";
        }
        else
        {
            LeftScore++;
            jugadorQueAnota = "Jugador Izquierdo";
        }

        marcadorText.text = LeftScore.ToString("00") + ":" + RightScore.ToString("00");

        // Reset posició i rotació
        pilota.transform.position = Vector3.zero;
        pilota.transform.rotation = Quaternion.identity;

        pilota.GetComponent<Pilota>().Aturar();

        // Comprobar si alguien ganó
        if (LeftScore >= golesParaGanar || RightScore >= golesParaGanar)
        {
            juegoTerminado = true;
            MostrarPanelFinal();
            return;
        }

        // Mostrar mensaje para pulsar C con quién anotó
        compteEnrereText.text = jugadorQueAnota + " anotó!\nPulsa C para continuar";
        esperantTecla = true;
    }

    private void Update()
    {
        if (esperantTecla && Input.GetKeyDown(KeyCode.C))
        {
            esperantTecla = false;
            compteEnrereText.text = ""; // limpiar texto
            StartCoroutine(CompteEnrere());
        }
    }

    private IEnumerator CompteEnrere()
    {
        int temps = 3;

        while (temps > 0)
        {
            compteEnrereText.text = temps.ToString();
            yield return new WaitForSeconds(1f);
            temps--;
        }

        compteEnrereText.text = "";

        // Activar IA si corresponde
        if (usarIA && rightPlayerIA != null)
            rightPlayerIA.enabled = true;

        // Iniciar moviment de la pilota
        pilota.GetComponent<Pilota>().IniciarMoviment();
    }

    private void MostrarPanelFinal()
    {
        string ganador = LeftScore > RightScore ? "Jugador Izquierdo" : "Jugador Derecho";
        compteEnrereText.text = "¡" + ganador + " gana!";

        if (panelFinal != null)
            panelFinal.SetActive(true);

        // Desactivar IA para que no siga moviéndose
        if (rightPlayerIA != null)
            rightPlayerIA.enabled = false;
    }

    // Botones del panel final
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu"); // Cambiar por el nombre exacto de la escena
    }

    public void VolverAJugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reinicia la escena
    }
}