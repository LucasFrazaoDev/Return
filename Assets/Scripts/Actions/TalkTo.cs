using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/TalkTo", fileName = "TalkTo")]
public class TalkTo : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (TalkToItem(controller, controller.Player.CurrentLocation.Items, noun))
            return;

        controller.CurrentText.text = "There is no " + noun + " here!";
    }

    private bool TalkToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun && item.ItemEnabled)
            {
                if (controller.Player.CanTalkToItem(controller, item))
                {
                    if (item.InteractWith(controller, "talkto"))
                        return true;
                }
                controller.CurrentText.text = "The " + noun + " doesn't respond!";
                return true;
            }
        }

        return false;
    }
}
