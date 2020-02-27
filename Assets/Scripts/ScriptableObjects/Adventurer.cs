﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Adventurer", menuName = "Adventurer")]
public class Adventurer : ScriptableObject
{
    public new string name;
    public int level;
    public Sprite portrait, sprite;
    public Race race;
    public AdventurerClass adventurerClass;
    public List<Trait> traits;
}