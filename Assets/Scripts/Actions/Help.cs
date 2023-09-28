using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Help", fileName ="Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string verb)
    {
        controller.CurrentText.text = "Type a verb followed by a noun (e.g. \"go north\")";
        controller.CurrentText.text += "\nAllowed verbs:\nGo, Examine, Get, Give, Use, Inventory, TalkTo, Say, Read, Help";
        controller.CurrentText.text += "\nIf you tired, just type Quit";
    }
}
