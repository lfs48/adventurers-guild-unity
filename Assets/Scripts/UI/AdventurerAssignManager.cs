using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerAssignManager : MonoBehaviour
{
    public List<AdventurerAssignBox> boxes;
    private Adventurer[] adventurers;
    public BoxCollider2D mainBox;
    // Start is called before the first frame update
    void Start()
    {
        adventurers = new Adventurer[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignAdventurer(Adventurer adventurer, Vector3 mousePos)
    {
        
        for (int i = 0; i < boxes.Count; i++)
        {
            if (boxes[i].collision.OverlapPoint(mousePos)) 
            {
                int idx = System.Array.IndexOf(adventurers, adventurer);
                if (idx >= 0) 
                { 
                    if (adventurers[i] is null) 
                    {
                        adventurers[idx] = null;
                        boxes[idx].ClearAdventurer();
                    } else {
                        adventurers[idx] = adventurers[i]; 
                        boxes[idx].SetAdventurer(adventurers[idx]);
                    }
                }
                adventurers[i] = adventurer;
                boxes[i].SetAdventurer(adventurer);
                break;
            }
        }

    }

    public void ClearAdventurer(Adventurer adventurer)
    {
        int i = System.Array.IndexOf(adventurers, adventurer);
        adventurers[i] = null;
        boxes[i].ClearAdventurer();
    }

    public Adventurer[] GetAdventurers()
    {
        return adventurers;
    }
}
