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

    private float transitionDuration = 2.0f;

    public AudioSource MusicAudioSource { get => m_musicAudioSource; private set => m_musicAudioSource = value; }
    public AudioSource SfxAudioSource { get => m_sfxAudioSource; private set => m_sfxAudioSource = value; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void UpdateMusicVolume(float volume)
    {
        m_musicAudioSource.volume = volume;
    }

    public void MakeTransition(int clipIndex)
    {
        StartCoroutine(TransitionToNextMusic(clipIndex));
    }

    private IEnumerator TransitionToNextMusic(int clipIndex)
    {
        float startVolume = Instance.MusicAudioSource.volume;

        while (Instance.MusicAudioSource.volume > 0f)
        {
            float progress = 1f - (Instance.MusicAudioSource.volume / startVolume);
            Instance.MusicAudioSource.volume = Mathf.Lerp(startVolume, 0f, progress + Time.deltaTime / transitionDuration);
            yield return null;
        }
        Instance.MusicAudioSource.volume = 0f;

        ChangeMusicClip(clipIndex);

        while (Instance.MusicAudioSource.volume < startVolume)
        {
            float progress = Instance.MusicAudioSource.volume / startVolume;
            Instance.MusicAudioSource.volume = Mathf.Lerp(0f, startVolume, progress + Time.deltaTime / transitionDuration);
            yield return null;
        }
        Instance.MusicAudioSource.volume = startVolume;
    }


    private void ChangeMusicClip(int clipIndex)
    {
        m_musicAudioSource.Stop();
        m_musicAudioSource.clip = m_musics[clipIndex];
        m_musicAudioSource.Play();
    }

    private void PlaySFX()
    {

    }


}
