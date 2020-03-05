using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private GameObject content;
    private RectTransform rt;
    private static Tooltip instance;
    public TextMeshProUGUI title, desc;
    // Start is called before the first frame update
    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        instance = this;
    }

    void Start()
    {
        instance.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Show(Tooltipable source, Vector3 pos)
    {
        rt.localScale = new Vector3(1,1,1);
        rt.position = pos;
        title.text = source.GetTooltipTitle();
        desc.text = source.GetTooltipDesc();
    }

    private void Hide()
    {
        rt.localScale = new Vector3(0,0,0);
    }

    public static void ShowTooltip(Trait trait, Vector3 pos)
    {
        instance.Show(trait, pos);
    }

    public static void HideTooltip()
    {
        instance.Hide();
    }
}
