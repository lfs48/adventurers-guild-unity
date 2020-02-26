using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdventurerWindow : ControlledWindow
{
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI nameText, bioText;

    public void SetAdventurer(Adventurer adventurer)
    {
        spriteRenderer.sprite = adventurer.sprite;
        nameText.text = adventurer.name;
        bioText.text = $"Level {adventurer.level} {adventurer.race} {adventurer.adventurerClass}";
    }

}
