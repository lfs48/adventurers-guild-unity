using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AdventurerManager : MonoBehaviour
{
    public Player player;
    public RosterSidebar sidebar;
    public Sprite[] sprites;
    public Sprite[] portraits;
    private List<string> names;
    private AdventurerClass[] classes;
    private Race[] races;
    public TraitManager traitManager;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRacesClasses();
        ReadNamesFromFile();
    }

    private void ReadNamesFromFile()
    {
        names = new List<string>();
        string path = Application.dataPath + "/Names.txt";
        foreach (string line in File.ReadLines(path))
        {
            names.Add(line);
        } 
    }

    private void InitializeRacesClasses()
    {
        classes = (AdventurerClass[]) AdventurerClass.GetValues(typeof(AdventurerClass));
        races = (Race[]) Race.GetValues(typeof(Race));
    }

    private string RandomName()
    {
        return names[Random.Range(0, names.Count)];
    }

    private AdventurerClass RandomClass()
    {
        return classes[Random.Range(0, classes.Length)];
    }

    private Race RandomRace()
    {
        return races[Random.Range(0, races.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAdventurer()
    {
        Adventurer adv =  (Adventurer) ScriptableObject.CreateInstance("Adventurer");
        adv.race = RandomRace();
        adv.adventurerClass = RandomClass();
        adv.name = RandomName();
        adv.level = 1;
        int rng = Random.Range(0, sprites.Length);
        adv.sprite = sprites[rng];
        adv.portrait = portraits[rng];
        adv.traits = new List<Trait>();
        adv.traits.Add(traitManager.RandomClassTrait(adv.adventurerClass));
        adv.traits.Add(traitManager.RandomRacialTrait(adv.race));
        player.roster.Add(adv);
        sidebar.AddAdventurerToRoster(adv);
    }

}
