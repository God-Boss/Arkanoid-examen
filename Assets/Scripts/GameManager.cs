using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;



    public void LoseHealt()
    {
        lives--;
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");

        }
        else
        {
            ResetLevel();
        }

    }
    public void ResetLevel()
    {
        FindFirstObjectByType<Ball>().ResetBall();
        FindFirstObjectByType<Player>().ResetPlayer();
    }

}
