using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read", fileName = "Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // use item in room
        if (ReadItem(controller, controller.player.currentLocation.items, noun))
            return;
        // use in inventory
        if (ReadItem(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun;
    }

    private bool ReadItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if(item.itemName == noun)
            {
                if(controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                        return true;
                }
                controller.currentText.text = "Nothing on the " + noun + " that you can read.";
                return true;
            }
        }

        return false;
    }
}
