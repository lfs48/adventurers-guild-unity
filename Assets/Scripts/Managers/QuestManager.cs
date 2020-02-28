using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest quest;
    public List<Adventurer> adventurers;
    public List<Trait> traits;
    public float timer, waitTime;
    public bool active;
    public int challengeIndex;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        traits = new List<Trait>();
        waitTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
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
    }

    public void Embark()
    {
        timer = waitTime;
        active = true;
        traits = new List<Trait>();
        for (int i = 0; i < adventurers.Count; i++)
        {
            traits.AddRange(adventurers[i].traits);
        }
    }

    bool ResolveChallenge(Challenge challenge)
    {
        Trait trait;
        int value = 0;
        for (int i = 0; i < traits.Count; i++)
        {
            trait = traits[i];
            if (challenge.relevantTraits.Contains(trait) )
            {
                value += trait.value;
            }
        }
        float rng = Random.Range(0.1f,1f);
        Debug.Log((float) value / (float) challenge.value);
        return (float) value / (float) challenge.value >= rng;
    }

    void CompleteQuest()
    {
        active = false;
        challengeIndex = 0;
        timer = waitTime;
        Debug.Log("Quest Complete!");
    }
}
