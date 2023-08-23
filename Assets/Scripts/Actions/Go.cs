using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Go", fileName = "Go")]

public class Go : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if(controller.Player.ChangeLocation(controller, noun))
            controller.DisplayLocation();
        else
            controller.CurrentText.text = "You can't go that way!";
    }
}
