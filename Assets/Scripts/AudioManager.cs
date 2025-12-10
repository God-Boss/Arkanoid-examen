using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public Image musicButtonImage;

    public Sprite musicOnSprite;  // Sprite con sonido
    public Sprite musicOffSprite; // Sprite sin sonido (tachado)

    private bool isMusicOn = true;

    void Start()
    {
        // Cargar el estado guardado
        isMusicOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        UpdateMusicState();
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        UpdateMusicState();

        // Guardar la preferencia
        PlayerPrefs.SetInt("MusicEnabled", isMusicOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateMusicState()
    {
        if (musicSource != null)
        {
            if (isMusicOn)
            {
                musicSource.Play();
            }
            else
            {
                musicSource.Pause();
            }
        }

        // Cambiar el sprite del botón
        if (musicButtonImage != null)
        {
            musicButtonImage.sprite = isMusicOn ? musicOnSprite : musicOffSprite;
        }
    }
}
