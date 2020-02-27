using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitManager : MonoBehaviour
{

    public List<Trait> humanTraits;
    public List<Trait> elfTraits;
    public List<Trait> dwarfTraits;
    public List<Trait> gnomeTraits;
    public List<Trait> orcTraits;
    public List<Trait> druidTraits;
    public List<Trait> mageTraits;
    public List<Trait> priestTraits;
    public List<Trait> rogueTraits;
    public List<Trait> warriorTraits;
    private Dictionary<Race, List<Trait>> raceTraits;
    private Dictionary<AdventurerClass, List<Trait>> classTraits;

    // Start is called before the first frame update
    void Start()
    {
        InitializeClassTraits();
        InitializeRaceTraits();
    }

    void InitializeRaceTraits() 
    {
        raceTraits = new Dictionary<Race, List<Trait>>();
        raceTraits[Race.Human] = humanTraits;
        raceTraits[Race.Elf] = elfTraits;
        raceTraits[Race.Dwarf] = dwarfTraits;
        raceTraits[Race.Gnome] = gnomeTraits;
        raceTraits[Race.Orc] = orcTraits;
    }

    void InitializeClassTraits()
    {
        classTraits = new Dictionary<AdventurerClass, List<Trait>>();
        classTraits[AdventurerClass.Druid] = druidTraits;
        classTraits[AdventurerClass.Mage] = mageTraits;
        classTraits[AdventurerClass.Priest] = priestTraits;
        classTraits[AdventurerClass.Rogue] = rogueTraits;
        classTraits[AdventurerClass.Warrior] = warriorTraits;
    }

    // Update is called once per frame
    public Trait RandomRacialTrait(Race race)
    {
        return raceTraits[race][Random.Range(0, raceTraits[race].Count)];
    }

    public Trait RandomClassTrait(AdventurerClass advClass)
    {
        return classTraits[advClass][Random.Range(0, classTraits[advClass].Count)];
    }
}
