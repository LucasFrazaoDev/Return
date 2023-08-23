using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Get", fileName ="Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        foreach (Item item in controller.Player.CurrentLocation.Items)
        {
            if(item.ItemEnabled && item.itemName == noun)
            {
                if (item.PlayerCanTake)
                {
                    controller.Player.Inventory.Add(item);
                    controller.Player.CurrentLocation.Items.Remove(item);
                    controller.CurrentText.text = "You take the " + noun;
                    return;
                }
            }
        }
        controller.CurrentText.text = "You can't get that";
    }
}
