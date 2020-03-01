using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveQuestUIPanel : QuestUIPanel
{
    private ActiveQuest quest;
    public Slider progress;
    public TextMeshProUGUI questStateText;
    public List<Image> portraits;

    void Update()
    {
        if (!(quest is null)) 
        {
            progress.value = quest.GetProgress();
            questStateText.text = quest.GetMessage();
        }
    }

    public void SetQuest(ActiveQuest quest)
    {
        this.quest = quest;
    }

    public void SetPortraits(Adventurer[] adventurers)
    {
        for (int i = 0; i < adventurers.Length; i++)
        {
            portraits[i].sprite = adventurers[i].portrait;
        }
    }
}

