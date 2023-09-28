using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_InputField m_textEntryField;
    [SerializeField] private TextMeshProUGUI m_logText;
    [SerializeField] private TextMeshProUGUI m_currentText;
    [SerializeField] private Image m_transitionImage;

    [Header("Gameplay elements")]
    [SerializeField] private Player m_player;
    [SerializeField] private Action[] m_actions;

    private float m_fillAmountProgress = 1.0f;
    private float m_transitionDuration = 2.0f;

    [TextArea]public string introText;

    public TextMeshProUGUI LogText { get => m_logText; set => m_logText = value; }
    public TextMeshProUGUI CurrentText { get => m_currentText; set => m_currentText = value; }
    public Player Player { get => m_player; private set => m_player = value; }
    public Action[] Actions { get => m_actions; private set => m_actions = value; }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TransitionEffect(true));

        LogText.text = introText;
        DisplayLocation();
        m_textEntryField.ActivateInputField();
    }

    public void DisplayLocation(bool additive = false)
    {
        string description = Player.CurrentLocation.description + "\n\n";
        description += Player.CurrentLocation.GetConnectionsText();
        description += Player.CurrentLocation.GetItemText();
        if (additive)
            CurrentText.text = CurrentText.text + "\n" + description;
        else
            CurrentText.text = description;
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(m_textEntryField.text);
        m_textEntryField.text = "";
        m_textEntryField.ActivateInputField();
    }

    private void LogCurrentText()
    {
        LogText.text += "\n";
        LogText.text += CurrentText.text;

        LogText.text += "\n\n";
        LogText.text += "<color=#aaccaaff>" + m_textEntryField.text + "</color>";
    }

    private void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] separatedWords = input.Split(delimiter);

        if (input == "quit")
        {
            StartCoroutine(TransitionEffect(false));
        }
        else
        {
            foreach (Action action in Actions)
            {
                if (action.Keyword.ToLower() == separatedWords[0])
                {
                    if (separatedWords.Length > 1)
                        action.RespondToInput(this, separatedWords[1]);
                    else
                        action.RespondToInput(this, "");

                    return;
                }
            }

            CurrentText.text = "Nothing happens! (Having trouble? Type Help)";
        }
    }

    private IEnumerator TransitionEffect(bool isStarting)
    {
        m_transitionImage.gameObject.SetActive(true);

        float startFillAmount = isStarting ? 1.0f : 0f;
        float endFillAmount = isStarting ? 0f : 1.0f;

        float elapsedTime = 0f;

        while (elapsedTime < m_transitionDuration)
        {
            m_fillAmountProgress = Mathf.Lerp(startFillAmount, endFillAmount, elapsedTime / m_transitionDuration);
            
            m_transitionImage.fillAmount = m_fillAmountProgress;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensuring that the fill amount remains at an appropriate value
        m_transitionImage.fillAmount = isStarting ? 0f : 1.0f;

        if(isStarting)
            m_transitionImage.gameObject.SetActive(false);

        if(!isStarting)
            SceneManager.LoadScene(0);
    }
}
