using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Tooltip("To know the difference the music AudioSource starts with an OST in the audioClip field")]
    [Header("Audio sources for music and SFX")]
    [SerializeField] private AudioSource m_musicAudioSource;
    [SerializeField] private AudioSource m_sfxAudioSource;

    [Space(10)]
    [Header("Music and SFX for the game")]
    [SerializeField] private AudioClip[] m_musics;
    [SerializeField] private AudioClip[] m_sfx;

    public AudioSource MusicAudioSource { get => m_musicAudioSource; private set => m_musicAudioSource = value; }
    public AudioSource SfxAudioSource { get => m_sfxAudioSource; private set => m_sfxAudioSource = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void UpdateMusicVolume(float volume)
    {
        m_musicAudioSource.volume = volume;
    }

    private void PlayMusic()
    {

    }

    private void PlaySFX()
    {

    }


}
