//Jean-Luc Hayes 01/30/16
//Button to enter the level
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void startGame()
    {
        Application.LoadLevel("Level 1");
    }
}
