using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/Say", fileName = "Say")]
public class Say : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (SayToItem(controller, controller.Player.CurrentLocation.Items, noun))
            return;

        controller.CurrentText.text = "Nothing responds!";
    }

    private bool SayToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if(item.ItemEnabled)
            {
                if (controller.Player.CanTalkToItem(controller, item))
                {
                    if(item.InteractWith(controller, "say", noun))
                        return true;
                }
            }
        }

        return false;
    }
}
