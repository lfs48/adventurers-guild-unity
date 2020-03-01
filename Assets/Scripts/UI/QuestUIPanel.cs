using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUIPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform rect;
    public TextMeshProUGUI nameText, descText;

    void Start()
    {

    }

    public void Show(Quest quest)
    {
        rect.localScale = new Vector3(1,1,1);
        nameText.text = quest.name;
        descText.text = quest.description;
    }

    public void Hide() 
    {
        rect.localScale = new Vector3(0,0,0);
    }
}
