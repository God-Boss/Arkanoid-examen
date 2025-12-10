using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigiBody2D;

    public float speed = 300;

    private Vector2 velocity;






    void Start()
    {
        velocity.x = Random.Range(-1, 1f);

        velocity.y = 1;
        rigiBody2D.AddForce(velocity*speed);


    }

    
  
}
