using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldMap : MonoBehaviour, IPointerDownHandler
{
    public QuestMarker questMarkerPrefab;
    private RectTransform rectTransform;

    public void SpawnQuest(Quest quest)
    {
        QuestMarker marker = Instantiate(questMarkerPrefab, rectTransform);
        marker.SetQuest(quest);
    }
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Hit");
    }
}
