using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdventurerWindow : ControlledWindow
{
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI nameText, bioText, raceTraitsText, classTraitsText;

    public void SetAdventurer(Adventurer adventurer)
    {
        spriteRenderer.sprite = adventurer.sprite;
        nameText.text = adventurer.name;
        bioText.text = $"Level {adventurer.level} {adventurer.race} {adventurer.adventurerClass}";
        raceTraitsText.text = "";
        classTraitsText.text = "";
        Trait trait;
        for (int i = 0; i < adventurer.traits.Count; i++)
        {
            trait = adventurer.traits[i];
            switch(trait.source) 
            {
                case("Race"): 
                {
                    raceTraitsText.text += $"\n {trait.name}: {trait.description}";
                    break;
                }
                case("Class"):
                {
                    classTraitsText.text += $"\n {trait.name}: {trait.description}";
                    break;
                }
                default: break;
            }
        }
    }

}
