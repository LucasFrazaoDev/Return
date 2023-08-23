using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    [TextArea] public string response;
    [SerializeField] private Action m_action;
    [SerializeField] private string m_textToMatch;
    [SerializeField] private List<Item> m_itemsToDisable = new List<Item>();
    [SerializeField] private List<Item> m_itemsToEnable = new List<Item>();
    [SerializeField] private List<Connection> m_connectionsToDisable = new List<Connection>();
    [SerializeField] private List<Connection> m_connectionsToEnable = new List<Connection>();
    [SerializeField] private Location teleportLocation = null;

    public Action Action { get => m_action; set => m_action = value; }
    public string TextToMatch { get => m_textToMatch; set => m_textToMatch = value; }
    public List<Item> ItemsToDisable { get => m_itemsToDisable; set => m_itemsToDisable = value; }
    public List<Item> ItemsToEnable { get => m_itemsToEnable; set => m_itemsToEnable = value; }
    public List<Connection> ConnectionsToDisable { get => m_connectionsToDisable; set => m_connectionsToDisable = value; }
    public List<Connection> ConnectionsToEnable { get => m_connectionsToEnable; set => m_connectionsToEnable = value; }
    public Location TeleportLocation { get => teleportLocation; set => teleportLocation = value; }
}
