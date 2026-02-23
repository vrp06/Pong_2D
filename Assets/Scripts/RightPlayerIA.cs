using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RightPlayerIA : MonoBehaviour
{
    public float velocitat = 5f;

    // Referència a la pilota
    public Transform ball;

    private Rigidbody2D rb;

    // Límites del mapa
    public float limitSuperior = 3.1f;
    public float limitInferior = -3.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.mass = 1000f;
    }

    private void Start()
    {
        // Si no s'ha assignat la pilota, la busca pel nom "Ball"
        if (ball == null)
        {
            GameObject b = GameObject.Find("Ball");
            if (b != null)
                ball = b.transform;
        }
    }

    private void Update()
    {
        if (ball == null) return;

        Vector2 posicioActual = rb.position;
        float direccio = 0f;

        // La IA segueix la posició vertical de la pilota
        if (ball.position.y > posicioActual.y)
            direccio = 1f;
        else if (ball.position.y < posicioActual.y)
            direccio = -1f;

        // Moviment
        Vector2 novaPos = posicioActual + new Vector2(0, direccio * velocitat * Time.deltaTime);

        // Evita sortir dels límits
        novaPos.y = Mathf.Clamp(novaPos.y, limitInferior, limitSuperior);

        rb.MovePosition(novaPos);
    }
}