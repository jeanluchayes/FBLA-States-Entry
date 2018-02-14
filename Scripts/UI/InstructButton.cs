//Jean-Luc Hayes 02/02/16
//Main Menu Instructions button
//instantiates the Instructions UI
using UnityEngine;
using System.Collections;

public class InstructButton : MonoBehaviour
{
    public Canvas canvas;
    public UnityEngine.UI.Image instruct;
    public UnityEngine.UI.Button instructExit;
    public UnityEngine.UI.Button exit;
    public UnityEngine.UI.Image background;

	// Use this for initialization
	void Awake ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void instructions()
    {
        UnityEngine.UI.Image backgrounds = Instantiate(background, background.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Image;
        backgrounds.transform.SetParent(canvas.transform, false);
        UnityEngine.UI.Image instructs = Instantiate(instruct, instruct.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Image;
        instructs.transform.SetParent(canvas.transform, false);
        UnityEngine.UI.Button instructExits = Instantiate(instructExit, instructExit.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Button;
        instructExits.transform.SetParent(canvas.transform, false);
        /*UnityEngine.UI.Button exits = Instantiate(exit, exit.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Button;
        exits.transform.SetParent(canvas.transform, false);*/
    }
}
