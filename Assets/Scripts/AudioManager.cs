using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Music")]
    public AudioSource musicSource;
    public Image musicButtonImage;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    [Header("Sound Effects")]
    public AudioSource sfxSource;
    public AudioClip ballBounceSound;
    public AudioClip blockBreakSound;
    public AudioClip loseLifeSound;

    private bool isMusicOn = true;

    private void Awake()
    {
        // Singleton para acceder desde otros scripts
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
                if (!musicSource.isPlaying)
                {
                    musicSource.Play();
                }
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

    // Métodos para efectos de sonido
    public void PlayBallBounce()
    {
        PlaySFX(ballBounceSound);
    }

    public void PlayBlockBreak()
    {
        PlaySFX(blockBreakSound);
    }

    public void PlayLoseLife()
    {
        PlaySFX(loseLifeSound);
    }

    private void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}