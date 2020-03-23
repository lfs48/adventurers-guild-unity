using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseoverIcon : MonoBehaviour
{
    private Tooltipable tooltip;
    public Image icon;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0,0,0);
        GameObject temp = GameObject.Find("MainCanvas");
        canvas = temp.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseEnter()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint( Camera.main.WorldToScreenPoint(transform.position)  + new Vector3(0f, -50f / canvas.scaleFactor, 0f) );
        Tooltip.ShowTooltip(tooltip, pos);
    }

    public void OnMouseExit()
    {
        Tooltip.HideTooltip();
    }

    public void SetTooltip(Tooltipable tooltip)
    {
        transform.localScale = new Vector3(1,1,1);
        this.tooltip = tooltip;
    }

    public void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
