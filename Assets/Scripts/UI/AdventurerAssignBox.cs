using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AdventurerAssignBox : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image image;
    private Adventurer adventurer;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 originalPosition;
    public AdventurerAssignManager manager;
    public BoxCollider2D collision;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        image = GetComponent<Image>();
        image.color = Color.clear;
    }
    
    public void SetAdventurer(Adventurer adventurer)
    {
        this.adventurer = adventurer;
        image.sprite = adventurer.portrait;
        image.color = Color.white;
    }

    public void ClearAdventurer()
    {
        this.adventurer = null;
        image.sprite = null;
        image.color = Color.clear;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        rectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = originalPosition;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        if (manager.mainBox.OverlapPoint(mousePos))
        {
            manager.AssignAdventurer(adventurer, mousePos);
        } else {
            manager.ClearAdventurer(adventurer);
        }
    }
    
}
