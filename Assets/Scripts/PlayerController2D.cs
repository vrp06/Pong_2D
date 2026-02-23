using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float velocitat = 5f;

    // Defineix si el jugador es mou vertical (esquerra) o horitzontal (dreta)
    public bool esJugadorEsquerra = true;

    private Rigidbody2D rb;

    // Límites del mapa (valors segons la posició de les parets)
    public float limitSuperior = 3.1f;
    public float limitInferior = -3.1f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.mass = 1000f; // Massa alta per no ser mogut per la pilota
    }

    private void Update()
    {
        Vector2 moviment = Vector2.zero;

        if (esJugadorEsquerra)
        {
            // Moviment vertical: W / S
            if (Input.GetKey(KeyCode.W)) moviment.y = velocitat * Time.deltaTime;
            if (Input.GetKey(KeyCode.S)) moviment.y = -velocitat * Time.deltaTime;

            // Clamp vertical per no travessar sostre / terra
            Vector2 novaPos = rb.position + moviment;
            novaPos.y = Mathf.Clamp(novaPos.y, limitInferior, limitSuperior);
            rb.MovePosition(novaPos);
        }
        else
        {
            // Moviment horitzontal: Up / Down
            if (Input.GetKey(KeyCode.DownArrow)) moviment.y = -velocitat * Time.deltaTime;
            if (Input.GetKey(KeyCode.UpArrow)) moviment.y = velocitat * Time.deltaTime;

            // Clamp vertical per no travessar sostre / terra
            Vector2 novaPos = rb.position + moviment;
            novaPos.y = Mathf.Clamp(novaPos.y, limitInferior, limitSuperior);
            rb.MovePosition(novaPos);
        }
    }
}
