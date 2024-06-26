﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestMarker : MonoBehaviour
{
    private QuestUIManager manager;
    private Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("QuestUI").GetComponent<QuestUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (quest.state == QuestState.Completed)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            manager.SetQuest(quest);
        }
    }

    public void SetQuest(Quest quest)
    {
        this.quest = quest;
        this.transform.localPosition = quest.location;
    }
}
