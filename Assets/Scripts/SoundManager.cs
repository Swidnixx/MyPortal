using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public AudioClip[] musics;
    public float sfxVolumeScale = 1.6f;
    AudioSource audioSource;
    int currentMusic;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musics[0];
        audioSource.Play();
    }

    private void Update()
    {
        if (audioSource.time >= musics[currentMusic].length - 0.1f)
        {
            currentMusic++;
            if (currentMusic >= musics.Length)
            {
                currentMusic = 0;
            }

            audioSource.clip = musics[currentMusic];
            audioSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, sfxVolumeScale);
    }
}
