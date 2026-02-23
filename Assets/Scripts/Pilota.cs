using UnityEngine;

public class Pilota : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocitat = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        IniciarMoviment();
    }

    public void IniciarMoviment()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f); // ángulo pequeño para no ser muy horizontal
        Vector2 direccio = new Vector2(x, y).normalized;
        rb.velocity = direccio * velocitat;
    }

    public void Aturar()
    {
        rb.velocity = Vector2.zero;
    }
}