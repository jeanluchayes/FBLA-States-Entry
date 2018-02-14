//Jean-Luc Hayes 11/30/16
//Exit button for the main menu
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

    }

    public void exitGame()
    {
        Application.Quit();
    }
}

