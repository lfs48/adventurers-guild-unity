using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosterSidebar : MonoBehaviour
{
    public Player player;
    public AdventurerPortrait advPortraitPrefab;
    private Transform tf;
    // Start is called before the first frame update

    void Awake()
    {
        tf = GetComponent<Transform>();
    }
    void Start()
    {
        setupRoster();
    }

    void setupRoster()
    {
        Adventurer[] roster = player.roster;
        for (int i = 0; i < roster.Length; i++)
        {
            AdventurerPortrait portrait = Instantiate(advPortraitPrefab, tf);
            portrait.adventurer = roster[i];
            portrait.transform.position = new Vector3(-6.271f,3.269f - (i*0.978f) , 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
