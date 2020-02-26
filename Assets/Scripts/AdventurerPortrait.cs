using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AdventurerPortrait : MonoBehaviour, IPointerDownHandler
{
    public Adventurer adventurer;
    public SpriteRenderer renderer;
    public TextMeshProUGUI nameText;
    public WindowController windowController;
    public void OnPointerDown(PointerEventData eventData)
    {
        windowController.setAdventurer(adventurer);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        windowController = GameObject.Find("WindowController").GetComponent<WindowController>();
        nameText.text = adventurer.name;
        renderer.sprite = adventurer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
