using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Give", fileName = "Give")]
public class Give : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if(controller.Player.HasItemByName(noun))
        {
            if (GiveToItem(controller, controller.Player.CurrentLocation.Items, noun))
                return;
            
            controller.CurrentText.text = "Nothing takes the " + noun;
            return;
        }

        controller.CurrentText.text = "You don't have " + noun + " to give.";
    }

    private bool GiveToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.ItemEnabled)
            {
                if (controller.Player.CanGiveToItem(controller, item))
                {
                    if (item.InteractWith(controller, "give", noun))
                        return true;
                }
            }
        }

        return false;
    }
}
