using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosterSidebar : MonoBehaviour
{
    public Player player;
    public AdventurerPortrait advPortraitPrefab;
    public Transform sidebar;
    // Start is called before the first frame update
    void Start()
    {
        setupRoster();
    }

    void setupRoster()
    {
        Adventurer[] roster = player.roster;
        for (int i = 0; i < roster.Length; i++)
        {
            AdventurerPortrait portrait = Instantiate(advPortraitPrefab, sidebar);
            portrait.adventurer = roster[i];
            portrait.transform.position = new Vector3(-6.271f,3.269f - (i*0.978f) , 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
