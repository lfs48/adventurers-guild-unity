using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trait", menuName = "Trait")]
public class Trait : ScriptableObject, Tooltipable
{
    public string name, description, source;
    public int value;
    public Sprite icon;

    public string GetTooltipTitle()
    {
        return name;
    }

    public string GetTooltipDesc()
    {
        return description;
    }
}