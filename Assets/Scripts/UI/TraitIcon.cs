using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitIcon : MonoBehaviour
{
    private Trait trait;
    public Image icon;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseEnter()
    {
        Vector3 pos = transform.position + new Vector3(2f, -1f, 0f);
        Tooltip.ShowTooltip(trait, pos);
    }

    public void OnMouseExit()
    {
        Tooltip.HideTooltip();
    }

    public void SetTrait(Trait trait)
    {
        transform.localScale = new Vector3(1,1,1);
        this.trait = trait;
        icon.sprite = trait.icon;
    }
}
