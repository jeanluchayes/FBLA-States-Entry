//Jean-Luc Hayes 11/29/16
//Controls the Score of the game through a static variable
using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    UnityEngine.UI.Text text;

	// Use this for initialization
	void Awake ()
    {
        text = GetComponent<UnityEngine.UI.Text>();
        score = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        text.text = "Score: " + score;
	}
}
