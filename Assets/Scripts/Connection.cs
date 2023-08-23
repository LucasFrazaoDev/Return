using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    [SerializeField] private string m_connectionName;
    [SerializeField] private string m_description;
    [SerializeField] private Location m_location;
    [SerializeField] private bool m_connectionEnabled;

    public string ConnectionName { get => m_connectionName; set => m_connectionName = value; }
    public string Description { get => m_description; set => m_description = value; }
    public Location Location { get => m_location; set => m_location = value; }
    public bool ConnectionEnabled { get => m_connectionEnabled; set => m_connectionEnabled = value; }
}
