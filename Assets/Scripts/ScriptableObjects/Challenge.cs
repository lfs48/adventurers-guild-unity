using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : ScriptableObject
{
    public new string name;
    public string description;
    public int value;
    public List<Trait> relevantTraits;
}
