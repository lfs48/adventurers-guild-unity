using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform rect;
    public TextMeshProUGUI nameText, descText;

    public Image[] challengeIcons;

    void Start()
    {

    }

    public void Show(Quest quest)
    {
        rect.localScale = new Vector3(1,1,1);
        nameText.text = quest.name;
        descText.text = quest.description;
        for (int i = 0; i < quest.challenges.Count; i++)
        {
            challengeIcons[i].sprite = quest.challenges[i].icon;
        }
    }

    public void Hide() 
    {
        rect.localScale = new Vector3(0,0,0);
    }
}
