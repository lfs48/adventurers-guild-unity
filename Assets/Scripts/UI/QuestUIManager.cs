using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    private RectTransform rect;
    public TextMeshProUGUI nameText, descriptionText;
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
        nameText.text = quest.name;
        descriptionText.text = quest.description;
        Show();
    }

    public void Show()
    {
        rect.localScale = new Vector3(1,1,1);
    }

    public void Hide()
    {
        rect.localScale = new Vector3(0,0,0);
    }
}
