using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Challenge", menuName = "Challenge")]
public class Challenge : ScriptableObject, Tooltipable
{
    public new string name;
    public string description;
    public int value;
    public List<Trait> relevantTraits;
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
