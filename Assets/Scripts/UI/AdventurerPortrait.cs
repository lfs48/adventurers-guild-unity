using System.Collections;
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
    public Image image;
    public TextMeshProUGUI nameText;
    public WindowController windowController;
    public AdventurerAssign advAssign;
    public void OnPointerDown(PointerEventData eventData)
    {
        windowController.ShowAdventurerWindow(adventurer);
        bar.localScale = new Vector3(0,0,0);
        dragSprite.transform.localScale = new Vector3(50,50,1);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        originalPos = rectTransform.position;
        rectTransform.position = new Vector3(mousePos.x, mousePos.y, rectTransform.position.z);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        windowController.ShowAdventurerWindow(adventurer);
        bar.localScale = new Vector3(1,1,1);
        dragSprite.transform.localScale = new Vector3(0,0,0);
        rectTransform.position = originalPos;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        if (advAssign.mainBox.OverlapPoint(mousePos))
        {
            advAssign.GetComponent<AdventurerAssign>().AssignAdventurer(adventurer, mousePos);
        } 
    }

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        GameObject temp = GameObject.Find("MainCanvas");
        canvas = temp.GetComponent<Canvas>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        windowController = GameObject.Find("WindowController").GetComponent<WindowController>();
        nameText.text = adventurer.name;
        image.sprite = adventurer.portrait;
        dragSprite.sprite = adventurer.portrait;
        advAssign = GameObject.Find("AdventurerAssign").GetComponent<AdventurerAssign>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

}
