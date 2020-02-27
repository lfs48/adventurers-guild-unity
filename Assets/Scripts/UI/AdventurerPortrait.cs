﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AdventurerPortrait : MonoBehaviour, IPointerDownHandler
{
    public Adventurer adventurer;
    public Image image;
    public TextMeshProUGUI nameText;
    public WindowController windowController;
    public void OnPointerDown(PointerEventData eventData)
    {
        windowController.ShowAdventurerWindow(adventurer);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        windowController = GameObject.Find("WindowController").GetComponent<WindowController>();
        nameText.text = adventurer.name;
        image.sprite = adventurer.portrait;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
