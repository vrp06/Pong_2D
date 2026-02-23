using UnityEngine;

public class SelectorJugador : MonoBehaviour
{

    PlayerController2D jugador;
    RightPlayerIA ia;

    void Start()
    {
        jugador = GetComponent<PlayerController2D>();
        ia = GetComponent<RightPlayerIA>();

        if (GameManager.usarIA)
        {
            ia.enabled = true;
            jugador.enabled = false;
        }
        else
        {
            ia.enabled = false;
            jugador.enabled = true;
        }
    }
}