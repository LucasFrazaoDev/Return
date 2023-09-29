using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : TransitionImageBase
{
    [Header("Main menu buttons")]
    [SerializeField] private Button m_startGameButton;
    [SerializeField] private Button m_quitGameButton;
    [SerializeField] private Button m_optionsGameButton;

    [Header("Options UI elements")]
    [SerializeField] private GameObject m_gameOptionsPanel;
    [SerializeField] private Slider m_musicVolumeSlider;
    [SerializeField] private Slider m_sfxVolumeSlider;
    [SerializeField] private Button m_closePanelGameButton;

    private float m_delayChangeMusic = 1.0f;

    private void Awake()
    {
        m_startGameButton.onClick.AddListener(StartGame);
        m_quitGameButton.onClick.AddListener(() => Application.Quit());
        m_optionsGameButton.onClick.AddListener(() => OpenOptionsPanel());
        m_closePanelGameButton.onClick.AddListener(() => CloseOptionsPanel());
    }

    private void Start()
    {
        StartCoroutine(TransitionEffect(true));
        m_gameOptionsPanel.SetActive(false);
        m_musicVolumeSlider.onValueChanged.AddListener(ChangeVolume);

        m_musicVolumeSlider.value = AudioManager.Instance.MusicAudioSource.volume;
    }

    private void StartGame()
    {
        StartCoroutine(TransitionEffect(false, 1));
        StartCoroutine(ChangeMusic());
    }

    private IEnumerator ChangeMusic()
    {
        //yield return new WaitForSeconds(m_delayChangeMusic);
        AudioManager.Instance.TransitionToNextMusic();
        yield return null;
    }

    private void ChangeVolume(float volume)
    {
        AudioManager.Instance.UpdateMusicVolume(volume);
    }

    private void OpenOptionsPanel()
    {
        m_gameOptionsPanel.SetActive(true);
    }

    private void CloseOptionsPanel()
    {
        m_gameOptionsPanel.SetActive(false);
    }
}
