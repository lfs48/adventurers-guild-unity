using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    private RectTransform rect;
    public TextMeshProUGUI nameText, descriptionText;
    public QuestManager questManager;
    public AdventurerAssignManager adventurerAssign;
    private Quest selectedQuest;
    public QuestUIPanel inactivePanel, activePanel;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuest(Quest quest)
    {
        selectedQuest = quest;
        if (selectedQuest.state == QuestState.Available)
        {   
            inactivePanel.Show(quest);
            activePanel.Hide();
        } else if (selectedQuest.state == QuestState.Active)
        {
            inactivePanel.Hide();
            activePanel.Show(quest);
        }
    }

    public void Embark()
    {
        questManager.ActivateQuest(selectedQuest, adventurerAssign.GetAdventurers() );
        inactivePanel.Hide();
        activePanel.Show(selectedQuest);

    }

    public void Hide()
    {
        activePanel.Hide();
        inactivePanel.Hide();
    }

}
