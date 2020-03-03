using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Challenge", menuName = "Challenge")]
public class Challenge : ScriptableObject
{
    public new string name;
    public string description;
    public int value;
    public List<Trait> relevantTraits;
    public Sprite icon;
}
