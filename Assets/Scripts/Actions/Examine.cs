using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Examine", fileName ="Examine")]
public class Examine : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // check item in room
        if (CheckItems(controller, controller.Player.CurrentLocation.Items, noun))
            return;
        // check item in inventory
        if (CheckItems(controller, controller.Player.Inventory, noun))
            return;

        controller.CurrentText.text = "You can't see a " + noun;
    }

    private bool CheckItems(GameController controller, List<Item> items, string noun)
    {
        foreach(Item item in items)
        {
            if(item.itemName == noun && item.ItemEnabled)
            {
                if (item.InteractWith(controller, "examine"))
                    return true;

                controller.CurrentText.text = "You see " + item.description;
                return true;
            }
        }
        return false;
    }
}
