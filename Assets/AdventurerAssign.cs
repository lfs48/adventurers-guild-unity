using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerAssign : MonoBehaviour
{
    private Adventurer[] adventurers;
    public List<BoxCollider2D> boxes;
    public List<Image> advSprites;
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
            if (boxes[i].OverlapPoint(mousePos)) 
            {
                int idx = System.Array.IndexOf(adventurers, adventurer);
                if (idx >= 0) 
                { 
                    if (adventurers[i] is null) 
                    {
                        adventurers[idx] = null;
                    } else {
                        adventurers[idx] = adventurers[i]; 
                    }
                }
                adventurers[i] = adventurer;
                break;
            }
        }

        for (int i = 0; i < adventurers.Length; i++)
        {
            if (!(adventurers[i] is null)) 
            { 
                advSprites[i].sprite = adventurers[i].portrait; 
            } else
            {
                advSprites[i].sprite = null;
            }
        }
    }
}
