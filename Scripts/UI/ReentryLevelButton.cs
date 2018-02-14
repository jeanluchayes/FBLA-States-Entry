//Jean-Luc Hayes 01/31/15
//Button to reentry the level
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class ReentryLevelButton : MonoBehaviour
{
    private UnityEngine.UI.Button myButton;
    // Use this for initialization
    void Start()
    {
        myButton = GetComponent<UnityEngine.UI.Button>();
        myButton.onClick.AddListener(() => reentryLevel());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void reentryLevel()
    {
        LevelManager.reentryLevel = true;
    }
}
