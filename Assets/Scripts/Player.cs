using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D ribiBody2D;

    private float inputValue;

    public float moveSpeed = 25;

    private Vector2 direction;

    Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }



    void Update()
    {
        inputValue = Input.GetAxisRaw("Horizontal");

        if (inputValue == 1)
        {
            direction = Vector2.right;
        }
        else if (inputValue == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }

        ribiBody2D.AddForce(direction * moveSpeed * Time.deltaTime * 100);
        
        
    }
    public void ResetPlayer()
    {
        transform.position = startPosition;
        ribiBody2D.linearVelocity = Vector2.zero;
    }
}
