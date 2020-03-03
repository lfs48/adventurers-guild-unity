using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventurerWindow : ControlledWindow
{
    public Image imageRenderer;
    public TextMeshProUGUI nameText, bioText;
    public Image[] raceTraits, classTraits;

    public void SetAdventurer(Adventurer adventurer)
    {
        imageRenderer.sprite = adventurer.sprite;
        nameText.text = adventurer.name;
        bioText.text = $"Level {adventurer.level} {adventurer.race} {adventurer.adventurerClass}";
        Trait trait;
        for (int i = 0; i < adventurer.traits.Count; i++)
        {
            trait = adventurer.traits[i];
            switch(trait.source) 
            {
                case("Race"): 
                {
                    raceTraits[i].sprite = trait.icon;
                    break;
                }
                case("Class"):
                {
                    classTraits[i].sprite = trait.icon;
                    break;
                }
                default: break;
            }
        }
    }

}
