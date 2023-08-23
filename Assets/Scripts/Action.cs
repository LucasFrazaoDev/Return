using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    [SerializeField] private string m_keyword;

    public string Keyword { get => m_keyword; set => m_keyword = value; }

    public abstract void RespondToInput(GameController controller, string noun);
}
