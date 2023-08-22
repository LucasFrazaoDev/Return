using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;
    [TextArea] public string description;
    public Connection[] connections;
    public List<Item> items = new List<Item>();

    public string GetItemText()
    {
        if (items.Count == 0) return "";

        string result = "You see ";
        bool first = true;
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if(!first) result += " and ";
                result += item.description;
                first = false;
            }
        }
        result += "\n";
        return result;
    }

    public string GetConnectionsText()
    {
        string result = "";
        foreach (Connection c in connections)
        {
            if (c.connectionEnabled)
                result += c.description + "\n";
        }

        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach (Connection c in connections)
        {
            if (c.connectionName.ToLower() == connectionNoun.ToLower())
                return c;
        }
        return null;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck && item.itemEnabled)
                return true;
        }
        return false;
    }
}
