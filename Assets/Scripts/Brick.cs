using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points = 10; // Puntos que da cada bloque

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Añadir puntos al GameManager
            FindFirstObjectByType<GameManager>().AddScore(points);

            // Destruir el bloque
            Destroy(gameObject);
        }
    }
}