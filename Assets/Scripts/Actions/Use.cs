using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use", fileName = "Use")]
public class Use : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // use item in room
        if (UseItem(controller, controller.Player.CurrentLocation.Items, noun))
            return;
        // use in inventory
        if (UseItem(controller, controller.Player.Inventory, noun))
            return;

        controller.CurrentText.text = "There is no " + noun;
    }

    private bool UseItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if(controller.Player.CanUseItem(controller, item))
                {
                    if (item.InteractWith(controller, "use"))
                        return true;
                }
                controller.CurrentText.text = "The " + noun + " does nothing";
                return true;
            }
        }
        return false;
    }
}
