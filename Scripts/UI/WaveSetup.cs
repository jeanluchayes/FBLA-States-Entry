//Jean-Luc Hayes 01/30/16
//Controls Wave Time text
//Depreciated as I removed the wave UI
using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    UnityEngine.UI.Text waveTime;

    // Use this for initialization
    void Awake ()
    {
        waveTime = GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        waveTime.text = "Time Till Next Wave: " + GameManagerPlay.timeLeft;
    }
}
