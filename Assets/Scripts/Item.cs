using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    [TextArea] public string description;
    [SerializeField] private bool m_playerCanTake = false;
    [SerializeField] private bool m_playerCanGiveTo = false;
    [SerializeField] private bool m_playerCanTalkTo = false;
    [SerializeField] private bool m_playerCanRead = false;
    [SerializeField] private bool m_itemEnabled = true;
    [SerializeField] private Item m_targetItem = null;
    [SerializeField] private Interaction[] m_interactions;

    public bool PlayerCanTake { get => m_playerCanTake; set => m_playerCanTake = value; }
    public bool PlayerCanGiveTo { get => m_playerCanGiveTo; set => m_playerCanGiveTo = value; }
    public bool PlayerCanTalkTo { get => m_playerCanTalkTo; set => m_playerCanTalkTo = value; }
    public bool PlayerCanRead { get => m_playerCanRead; set => m_playerCanRead = value; }
    public bool ItemEnabled { get => m_itemEnabled; set => m_itemEnabled = value; }
    public Item TargetItem { get => m_targetItem; set => m_targetItem = value; }
    public Interaction[] Interactions { get => m_interactions; set => m_interactions = value; }

    public bool InteractWith(GameController controller, string actionKeyword, string noun = "")
    {
        foreach (Interaction interaction in Interactions)
        {
            if(interaction.Action.Keyword == actionKeyword)
            {
                if (noun != "" && noun.ToLower() != interaction.TextToMatch.ToLower())
                    continue;

                foreach(Item disableItem in interaction.ItemsToDisable)
                    disableItem.ItemEnabled = false;

                foreach(Item enableItem in interaction.ItemsToEnable)
                    enableItem.ItemEnabled = true;
                
                foreach(Connection disableConnection in interaction.ConnectionsToDisable)
                    disableConnection.ConnectionEnabled = false;

                foreach(Connection enableConnection in interaction.ConnectionsToEnable)
                    enableConnection.ConnectionEnabled = true;

                if(interaction.TeleportLocation != null)
                    controller.Player.Teleport(controller, interaction.TeleportLocation);

                controller.CurrentText.text = interaction.response;
                controller.DisplayLocation(true);
                return true;
            }
        }
        return false;
    }
}
