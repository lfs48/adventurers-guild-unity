using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosterSidebar : MonoBehaviour
{
    public Player player;
    public AdventurerPortrait advPortraitPrefab;
    public Transform contentContainer;
    private Transform tf;
    private List<Adventurer> roster;
    // Start is called before the first frame update

    void Awake()
    {
        tf = GetComponent<Transform>();
    }
    void Start()
    {
        SetupRoster();
    }

    void SetupRoster()
    {
        roster = player.roster;
        for (int i = 0; i < roster.Count; i++)
        {
            AdventurerPortrait portrait = Instantiate(advPortraitPrefab, contentContainer);
            portrait.adventurer = roster[i];
        }
    }

    public void AddAdventurerToRoster(Adventurer adventurer)
    {
        AdventurerPortrait portrait = Instantiate(advPortraitPrefab, contentContainer);
        portrait.adventurer = adventurer;
        roster.Add(adventurer);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
