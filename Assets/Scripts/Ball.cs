using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigiBody2D;
    public float speed = 300;

    private Vector2 velocity;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            FindAnyObjectByType<GameManager>().LoseHealth();
        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rigiBody2D.linearVelocity = Vector2.zero;

        
        velocity.x = Random.Range(-0.2f, 0.2f);
        velocity.y = 1;

        rigiBody2D.AddForce(velocity.normalized * speed);
    }
}