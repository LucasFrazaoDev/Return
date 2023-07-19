using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;
    [TextArea] public string description;
    public Connection[] connections;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
