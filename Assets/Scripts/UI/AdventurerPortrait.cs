﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AdventurerPortrait : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform rectTransform, bar;
    public SpriteRenderer dragSprite;
    [SerializeField] private Canvas canvas;
    private Vector3 originalPos;
    public Adventurer adventurer;
    public Image image, grayOut;
    public TextMeshProUGUI nameText;
    public WindowController windowController;
    public AdventurerAssignManager advAssign;
    public Slider hpBar;
    private bool drag;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (adventurer.state == AdventurerState.Available) {
            drag = true;
            windowController.ShowAdventurerWindow(adventurer);
            bar.localScale = new Vector3(0,0,0);
            dragSprite.transform.localScale = new Vector3(50,50,1);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            originalPos = rectTransform.position;
            rectTransform.position = new Vector3(mousePos.x, mousePos.y, rectTransform.position.z);
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (drag) {
            windowController.ShowAdventurerWindow(adventurer);
            bar.localScale = new Vector3(1,1,1);
            dragSprite.transform.localScale = new Vector3(0,0,0);
            rectTransform.position = originalPos;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            if (advAssign.mainBox.OverlapPoint(mousePos))
            {
                advAssign.AssignAdventurer(adventurer, mousePos);
            } 
            drag = false;
        }
        
    }

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        GameObject temp = GameObject.Find("MainCanvas");
        canvas = temp.GetComponent<Canvas>();
        drag = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        windowController = GameObject.Find("WindowController").GetComponent<WindowController>();
        nameText.text = adventurer.name;
        image.sprite = adventurer.portrait;
        dragSprite.sprite = adventurer.portrait;
        hpBar.maxValue = adventurer.maxHP;
        hpBar.value = adventurer.currentHP;
        advAssign = GameObject.Find("AdventurerAssign").GetComponent<AdventurerAssignManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Color temp;
        switch(adventurer.state)
        {
            case(AdventurerState.Available):
                temp = grayOut.color;
                temp.a = 0f;
                grayOut.color = temp;
                break;
            case(AdventurerState.Questing):
                temp = grayOut.color;
                temp.a = 0.5f;
                grayOut.color = temp;
                break;
        }
        hpBar.value = adventurer.currentHP;
        Image hpImage = hpBar.fillRect.GetComponent<Image>();
        if ( (float) adventurer.currentHP / (float) adventurer.maxHP > 0.5)
        {
            hpImage.color = Color.green;
        } else if ( (float) adventurer.currentHP / (float) adventurer.maxHP > 0.2)
        {
            hpImage.color = Color.yellow;
        } else
        {
            hpImage.color = Color.red;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (drag) {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        
    }

}
