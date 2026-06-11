using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private bool playOnStart = true;
    [SerializeField] [Range(0f, 1f)] private float volume = 0.5f;
    [SerializeField] private bool loop = true;

    private AudioSource audioSource;

    void Awake()
    {
        // Ensure the AudioSource component exists
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        audioSource.loop = loop;
        audioSource.volume = volume;

        if (playOnStart && musicClip != null)
        {
            PlayMusic();
        }
    }

    /// <summary>
    /// Stops all BackgroundMusic instances currently playing before playing this one.
    /// Call this if you want to ensure no other music is playing.
    /// </summary>
    public static void StopAllMusic()
    {
        BackgroundMusic[] allMusic = FindObjectsByType<BackgroundMusic>(FindObjectsSortMode.None);
        foreach (BackgroundMusic bgm in allMusic)
        {
            bgm.StopMusic();
        }
    }

    public void PlayMusic()
    {
        if (musicClip == null)
        {
            Debug.LogWarning("BackgroundMusic: No music clip assigned!");
            return;
        }

        // Stop any other BackgroundMusic instances first
        StopAllMusic();

        audioSource.clip = musicClip;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        audioSource.volume = volume;
    }
}