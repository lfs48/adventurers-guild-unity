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
}

