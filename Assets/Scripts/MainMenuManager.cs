using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private TextMeshProUGUI m_versionText;

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

        m_versionText.text = $"V_{Application.version}";
        m_musicVolumeSlider.value = AudioManager.Instance.MusicAudioSource.volume;
    }

    private void StartGame()
    {
        StartCoroutine(TransitionEffect(false, 1));
        AudioManager.Instance.MakeTransition(1);
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
