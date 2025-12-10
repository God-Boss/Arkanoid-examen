using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject stagePanel; // El panel del menú

    public void PlayGame()
    {
        // Ocultar el menú
        if (stagePanel != null)
        {
            stagePanel.SetActive(false);
        }

        // Reanudar el tiempo (por si estaba pausado)
        Time.timeScale = 1f;
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