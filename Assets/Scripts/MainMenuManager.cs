using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : TransitionImageBase
{
    [SerializeField] private Button m_startGameButton;
    [SerializeField] private Button m_QuitGameButton;

    private void Awake()
    {
        m_startGameButton.onClick.AddListener(StartGame);
        m_QuitGameButton.onClick.AddListener(() => Application.Quit());
    }

    private void Start()
    {
        StartCoroutine(TransitionEffect(true));
    }

    private void StartGame()
    {
        StartCoroutine(TransitionEffect(false, 1));
    }
}
