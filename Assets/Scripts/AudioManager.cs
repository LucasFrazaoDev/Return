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


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void PlayMusic()
    {

    }

    private void PlaySFX()
    {

    }


}
