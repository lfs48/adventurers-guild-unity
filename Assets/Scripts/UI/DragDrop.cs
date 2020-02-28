using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private Vector3 originalPos;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        GameObject temp = GameObject.Find("MainCanvas");
        canvas = temp.GetComponent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        originalPos = rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = originalPos;
    }

    public void OnPointerDown (PointerEventData eventData) {
        Debug.Log("click");
    }
 
    public void OnPointerUp (PointerEventData eventData) {
        Debug.Log("release");
    }

}
