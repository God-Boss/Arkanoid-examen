using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigiBody2D;
    public float speed = 300;

    private Vector2 velocity;
    private Vector2 startPosition;

    private bool isLaunched = false;
    private Transform playerTransform;
    public Vector2 offsetFromPlayer = new Vector2(0, 0.5f); // Ajusta según tu juego

    void Start()
    {
        startPosition = transform.position;
        playerTransform = FindFirstObjectByType<Player>().transform;
        ResetBall();
    }

    void Update()
    {
        // Si la bola no está lanzada, sigue al paddle
        if (!isLaunched && playerTransform != null)
        {
            transform.position = (Vector2)playerTransform.position + offsetFromPlayer;

            // Lanzar al pulsar Espacio (Jump)
            if (Input.GetButtonDown("Jump"))
            {
                LaunchBall();
            }
        }
    }

    private void LaunchBall()
    {
        isLaunched = true;

        // Desviación muy pequeña en X (entre -0.2 y 0.2)
        velocity.x = Random.Range(-0.2f, 0.2f);
        velocity.y = 1;

        rigiBody2D.AddForce(velocity.normalized * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            FindAnyObjectByType<GameManager>().LoseHealth();
        }
        else
        {
            // Sonido de rebote
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlayBallBounce();
            }
        }
    }

    public void ResetBall()
    {
        isLaunched = false;
        transform.position = startPosition;
        rigiBody2D.linearVelocity = Vector2.zero;
    }
}