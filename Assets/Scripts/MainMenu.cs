using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject stagePanel;
    private bool isPaused = false;

    public void PlayGame()
    {
        // Ocultar el menú y reanudar
        if (stagePanel != null)
        {
            stagePanel.SetActive(false);
        }

        isPaused = false;
        Time.timeScale = 1f;

        // Reanudar música
        if (AudioManager.instance != null && AudioManager.instance.musicSource != null)
        {
            AudioManager.instance.musicSource.UnPause();
        }
    }

    public void PauseGame()
    {
        // Mostrar el menú de pausa
        if (stagePanel != null)
        {
            stagePanel.SetActive(true);
        }

        isPaused = true;
        Time.timeScale = 0f;

        // Pausar música
        if (AudioManager.instance != null && AudioManager.instance.musicSource != null)
        {
            AudioManager.instance.musicSource.Pause();
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}