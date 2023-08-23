using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Inventory", fileName ="Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if(controller.Player.Inventory.Count == 0)
        {
            controller.CurrentText.text = "You have nothing!";
            return;
        }

        string result = "You have";

        bool first = true;
        foreach (Item item in controller.Player.Inventory)
        {
            if(first)
                result += " a " + item.itemName;
            else
                result += " and a " + item.itemName;

            first = false;
        }
        controller.CurrentText.text = result;
    }
}
