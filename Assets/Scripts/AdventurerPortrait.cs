using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventurerPortrait : MonoBehaviour
{
    public Adventurer adventurer;
    public SpriteRenderer renderer;
    public TextMeshProUGUI nameText;
    
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = adventurer.name;
        renderer.sprite = adventurer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
