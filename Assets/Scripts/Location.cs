using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField] private string m_locationName;
    [SerializeField] private Connection[] m_connections;
    [SerializeField] private List<Item> m_items = new List<Item>();

    [TextArea] public string description;

    public string LocationName { get => m_locationName; set => m_locationName = value; }
    public Connection[] Connections { get => m_connections; set => m_connections = value; }
    public List<Item> Items { get => m_items; set => m_items = value; }

    public string GetItemText()
    {
        if (Items.Count == 0) return "";

        string result = "You see ";
        bool first = true;
        foreach (Item item in Items)
        {
            if (item.ItemEnabled)
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
        foreach (Connection c in Connections)
        {
            if (c.ConnectionEnabled)
                result += c.Description + "\n";
        }

        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach (Connection c in Connections)
        {
            if (c.ConnectionName.ToLower() == connectionNoun.ToLower())
                return c;
        }
        return null;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in Items)
        {
            if (item == itemToCheck && item.ItemEnabled)
                return true;
        }
        return false;
    }
}
