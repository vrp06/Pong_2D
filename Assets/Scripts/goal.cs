using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Enviem la posició x de la porteria al GameManager
        gameManager.GolMarcat(transform.position.x);
    }
}
