using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventurerWindow : ControlledWindow
{
    public Image imageRenderer;
    public TextMeshProUGUI nameText, bioText;
    public MouseoverIcon[] raceTraits, classTraits;

    public void SetAdventurer(Adventurer adventurer)
    {
        imageRenderer.sprite = adventurer.sprite;
        nameText.text = adventurer.name;
        bioText.text = $"Level {adventurer.level} {adventurer.race} {adventurer.adventurerClass}";
        Trait trait;
        int raceIdx = 0;
        int classIdx = 0;
        for (int i = 0; i < adventurer.traits.Count; i++)
        {
            trait = adventurer.traits[i];
            switch(trait.source) 
            {
                case("Race"): 
                {
                    raceTraits[raceIdx].SetTooltip(trait);
                    raceTraits[raceIdx].SetIcon(trait.icon);
                    raceIdx++;
                    break;
                }
                case("Class"):
                {
                    classTraits[classIdx].SetTooltip(trait);
                    classTraits[classIdx].SetIcon(trait.icon);
                    classIdx++;
                    break;
                }
                default: break;
            }
        }
    }

}
