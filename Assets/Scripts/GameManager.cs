using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;

    // Referencias UI
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    private void Start()
    {
        UpdateUI();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void LoseHealth()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            ResetLevel();
        }
    }

    private void UpdateUI()
    {
        if (livesText != null)
        {
            livesText.text = "Vidas: " + lives;
        }

        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + score;
        }
    }

    private void GameOver()
    {
        // Pausar el juego
        Time.timeScale = 0f;

        // Mostrar panel de Game Over
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void ResetLevel()
    {
        FindFirstObjectByType<Ball>().ResetBall();
        FindFirstObjectByType<Player>().ResetPlayer();
    }

    public void RetryGame()
    {
        // Restaurar el tiempo
        Time.timeScale = 1f;

        // Recargar la escena del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // Para volver al menu principal (si tienes uno)
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Cambia por el nombre de tu menú
    }
}
