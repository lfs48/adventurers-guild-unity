using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<ActiveQuest> activeQuests;
    public ActiveQuest activeQuestPrefab;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        activeQuests = new List<ActiveQuest>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public ActiveQuest ActivateQuest(Quest quest, Adventurer[] adventurers)
    {
        ActiveQuest activeQuest = Instantiate(activeQuestPrefab, tf);
        activeQuest.Initialize(this, quest, adventurers);
        activeQuests.Add(activeQuest);
        quest.state = QuestState.Active;
        return activeQuest;
    }

    public void CompleteQuest(ActiveQuest activeQuest)
    {
        activeQuests.Remove(activeQuest);
        Destroy(activeQuest.gameObject);
    }
}
