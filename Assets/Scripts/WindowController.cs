﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WindowState
{
    CLOSED, ADVENTURER
}
public class WindowController : MonoBehaviour
{
    private WindowState state;
    private GameObject controller;
    private Dictionary<string, ControlledWindow> windows;
    private ControlledWindow activeWindow;

    void Awaken() 
    {
        controller = GetComponent<GameObject>();   
    }
    // Start is called before the first frame update
    void Start()
    {
        state = WindowState.CLOSED;
        windows = new Dictionary<string, ControlledWindow>();
        windows.Add("empty", GameObject.Find("EmptyPanel").GetComponent<ControlledWindow>() );
        windows.Add("adventurer", GameObject.Find("AdvPanel").GetComponent<ControlledWindow>() );
        activeWindow = windows["empty"];
    }

    // Update is called once per frame
    void Update()
    {
        activeWindow.HideWindow();
        switch (state)
        {
            case WindowState.CLOSED:
            {
                break;
            } 
            case WindowState.ADVENTURER: 
            {
                activeWindow = windows["adventurer"];
                activeWindow.ShowWindow();
                break;
            }
            default: break;
        }
    }

    public void setAdventurer(Adventurer adv)
    {
        state = WindowState.ADVENTURER;
    }
}