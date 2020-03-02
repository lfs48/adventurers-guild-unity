using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActiveQuestState
{
    Embarking, AttemptingChallenge, DefeatedChallenge, FailedChallenge, Success
}

public class ActiveQuest : MonoBehaviour
{
    public QuestManager manager;
    private Quest quest;
    private  Adventurer[] adventurers;
    private List<Trait> assignedTraits;
    private float timer, waitTime;
    private int challengeIndex;
    private ActiveQuestState state;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            switch(state) 
            {
                case ActiveQuestState.Embarking: 
                case ActiveQuestState.DefeatedChallenge: 
                case ActiveQuestState.FailedChallenge: 
                    BeginNextChallenge();
                    break;
                case ActiveQuestState.AttemptingChallenge: 
                    bool success = ResolveChallenge(quest.challenges[challengeIndex]);
                    if (success && challengeIndex >= quest.challenges.Count - 1) {CompleteQuest(); }
                    else if (success) {SucceedChallenge(); }
                    else { FailChallenge(); }
                    break;
                case ActiveQuestState.Success: 
                    EndQuest();
                    break;
            }
        }
    }

    public void Initialize(QuestManager manager, Quest quest, Adventurer[] adventurers)
    {
        state = ActiveQuestState.Embarking;
        this.manager = manager;
        this.quest = quest;
        this.adventurers = adventurers;
        waitTime = 4f;
        timer = waitTime;
        assignedTraits = new List<Trait>();
        for (int i = 0; i < adventurers.Length; i++)
        {
            assignedTraits.AddRange(adventurers[i].traits);
        }
    }

    void BeginNextChallenge()
    {
        state = ActiveQuestState.AttemptingChallenge;
        timer = waitTime;
    }

    void SucceedChallenge()
    {
        state = ActiveQuestState.DefeatedChallenge;
        challengeIndex++;
        timer = waitTime / 2;
    }

    void FailChallenge()
    {
        state = ActiveQuestState.FailedChallenge;
        timer = waitTime / 2;
    }

    bool ResolveChallenge(Challenge challenge)
    {
        Trait trait;
        int value = 0;
        for (int i = 0; i < assignedTraits.Count; i++)
        {
            trait = assignedTraits[i];
            if (challenge.relevantTraits.Contains(trait) )
            {
                value += trait.value;
            }
        }
        float rng = Random.Range(0.1f,1f);
        return (float) value / (float) challenge.value >= rng;
    }

    void CompleteQuest()
    {
        state = ActiveQuestState.Success;
        timer = waitTime / 2;
        challengeIndex++;
        quest.state = QuestState.Completed;
        for (int i = 0; i < adventurers.Length; i++)
        {
            adventurers[i].state = AdventurerState.Available;
        }
    }

    void EndQuest()
    {
        manager.CompleteQuest(this);
    }

    public float GetProgress()
    {
        return (float) (challengeIndex) / (float) quest.challenges.Count;
    }

    public string GetMessage()
    {
        switch(state)
        {
            case ActiveQuestState.Embarking: return "Embarking on quest...";
            case ActiveQuestState.AttemptingChallenge: return $"Attempting challenge: {quest.challenges[challengeIndex].name}";
            case ActiveQuestState.DefeatedChallenge: return $"Defeated challenge: {quest.challenges[challengeIndex - 1].name}";
            case ActiveQuestState.FailedChallenge: return $"Failed challenge: {quest.challenges[challengeIndex].name}";
            case ActiveQuestState.Success: return "Quest complete! Bringing home loot";

            default: return "";
        }
    }

}
