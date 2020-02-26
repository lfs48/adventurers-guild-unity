using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledWindow : MonoBehaviour
{
    private RectTransform rect;
    void Awake() {
        rect = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        HideWindow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWindow()
    {
        rect.localScale = new Vector3(1, 1, 1);
    }

    public void HideWindow()
    {
        rect.localScale = new Vector3(0,0,0);
    }
}
