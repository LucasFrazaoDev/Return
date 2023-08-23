using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Location m_currentLocation;
    [SerializeField] private List<Item> m_inventory = new List<Item>();

    public Location CurrentLocation { get => m_currentLocation; set => m_currentLocation = value; }
    public List<Item> Inventory { get => m_inventory; set => m_inventory = value; }

    public bool ChangeLocation(GameController controller, string connetionNoun)
    {
        Connection connection = CurrentLocation.GetConnection(connetionNoun);
        if(connection != null)
        {
            if (connection.ConnectionEnabled)
            {
                CurrentLocation = connection.Location;
                return true;
            }
        }
        return false;
    }

    public void Teleport(GameController controller, Location destination)
    {
        CurrentLocation = destination;
    }

    internal bool CanUseItem(GameController controller, Item item)
    {
        if (item.TargetItem == null)
            return true;

        if (HasItem(item.TargetItem))
            return true;

        if(CurrentLocation.HasItem(item.TargetItem))
            return true;

        return false;
    }

    internal bool CanReadItem(GameController controller, Item item)
    {
        if (item.TargetItem == null)
            return true;

        if (HasItem(item.TargetItem))
            return true;

        if (CurrentLocation.HasItem(item.TargetItem))
            return true;

        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach (Item item in Inventory)
        {
            if(item == itemToCheck && item.ItemEnabled)
                return true;
        }
        return false;
    }

    internal bool CanTalkToItem(GameController controller, Item item)
    {
        return item.PlayerCanTalkTo;
    }

    internal bool CanGiveToItem(GameController controller, Item item)
    {
        return item.PlayerCanGiveTo;
    }

    public bool HasItemByName(string noun)
    {
        foreach (Item item in Inventory)
            if(item.itemName.ToLower() == noun.ToLower()) return true;
        return false;
    }
}
