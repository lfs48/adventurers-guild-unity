using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState
{
    Available, Active, Completed
}

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public new string name;
    public string description;
    public List<Challenge> challenges;
    public QuestState state;
    public Vector3 location;
}
