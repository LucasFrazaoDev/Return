using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button m_startGameButton;
    [SerializeField] private Button m_QuitGameButton;

    private void Awake()
    {
        m_startGameButton.onClick.AddListener(StartGame);
        m_QuitGameButton.onClick.AddListener(() => Application.Quit());
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
