using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public Player player;
    public TMP_InputField textEntryField;
    public TextMeshProUGUI logText;
    public TextMeshProUGUI currentText;

    [TextArea]public string introText;

    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation()
    {
        string description = player.currentLocation.description + "\n\n";
        description += player.currentLocation.GetConnectionsText();
        currentText.text = description;
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    private void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";
    }

    private void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] separatedWords = input.Split(delimiter);

        // TODO
        // Process these commands (separateWords)

        currentText.text = "Nothing happens! (having trouble? Type Help)";
    }
}
