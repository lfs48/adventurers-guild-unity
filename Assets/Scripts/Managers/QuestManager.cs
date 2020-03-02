using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<ActiveQuest> activeQuests;
    public ActiveQuest activeQuestPrefab;
    public WorldMap map;
    private Transform tf;
    public List<Quest> possibleQuests;
    private List<Quest> availableQuests;
    private float questSpawnTime, questTimer;
    // Start is called before the first frame update
    void Start()
    {
        questSpawnTime = 10f;
        questTimer = questSpawnTime;
        activeQuests = new List<ActiveQuest>();
        availableQuests = new List<Quest>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (possibleQuests.Count > 0)
        {
            questTimer -= Time.deltaTime;
            if (questTimer <= 0)
            {
                MakeQuestAvailable();
            }
        }
    }

    public void MakeQuestAvailable()
    {
        questTimer = questSpawnTime;
        Quest quest = possibleQuests[possibleQuests.Count - 1];
        map.SpawnQuest(quest);
        availableQuests.Add(quest);
        possibleQuests.Remove(quest);
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
