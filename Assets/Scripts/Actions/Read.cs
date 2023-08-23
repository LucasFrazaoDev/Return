using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read", fileName = "Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // use item in room
        if (ReadItem(controller, controller.Player.CurrentLocation.Items, noun))
            return;
        // use in inventory
        if (ReadItem(controller, controller.Player.Inventory, noun))
            return;

        controller.CurrentText.text = "There is no " + noun;
    }

    private bool ReadItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if(item.itemName == noun)
            {
                if(controller.Player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                        return true;
                }
                controller.CurrentText.text = "Nothing on the " + noun + " that you can read.";
                return true;
            }
        }

        return false;
    }
}
