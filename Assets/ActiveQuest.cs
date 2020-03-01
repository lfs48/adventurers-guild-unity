using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveQuest : MonoBehaviour
{
    public QuestManager manager;
    private Quest quest;
    private  Adventurer[] adventurers;
    private List<Trait> assignedTraits;
    private float timer, waitTime;
    private int challengeIndex;
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
            bool success = ResolveChallenge(quest.challenges[challengeIndex]);
            timer = waitTime;
            if (success)
            {
                challengeIndex++;
                if (challengeIndex >= quest.challenges.Count) {
                    CompleteQuest();
                } else {
                    Debug.Log("Challenge Defeated");
                }
            } else {
                Debug.Log("Failed Challenge");
            }
        }
    }

    public void Initialize(QuestManager manager, Quest quest, Adventurer[] adventurers)
    {
        this.manager = manager;
        this.quest = quest;
        this.adventurers = adventurers;
        waitTime = 2f;
        timer = waitTime;
        assignedTraits = new List<Trait>();
        for (int i = 0; i < adventurers.Length; i++)
        {
            assignedTraits.AddRange(adventurers[i].traits);
        }
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
        challengeIndex = 0;
        timer = waitTime;
        Debug.Log("Quest Complete!");
        quest.state = QuestState.Completed;
        Debug.Log(this);
        manager.CompleteQuest(this);
    }

}
