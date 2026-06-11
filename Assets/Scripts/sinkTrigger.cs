using System;
using UnityEngine;

public class sinkTrigger : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip musicClip;
    [SerializeField] [Range(0f, 1f)] private float volume = 0.5f;
    [SerializeField] private bool loop = true;

    private AudioSource audioSource;

    public static event Action waterStart;

    void Awake()
    {
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
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hi");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("tripped_sink");
            
            // Stop any background music first, then play this clip
            if (musicClip != null)
            {
                BackgroundMusic.StopAllMusic();
                audioSource.clip = musicClip;
                audioSource.Play();
            }
            
            waterStart?.Invoke();
        }
    }
}