using UnityEngine;

public class Brickj : MonoBehaviour
{






    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }


    }
}
