//Jean-Luc Hayes 02/02/16
//Exit instructions main menu button
using UnityEngine;
using System.Collections;

public class ExitInstruct : MonoBehaviour
{
    public UnityEngine.UI.Image instruct;
    public UnityEngine.UI.Image instructB;

    private GameObject[] pieces;
    private GameObject[] piecesB;
    private GameObject[] piecesBu;

	// Use this for initialization
	void Awake ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        pieces = GameObject.FindGameObjectsWithTag("instruct");
        piecesB = GameObject.FindGameObjectsWithTag("instructB");
        piecesBu = GameObject.FindGameObjectsWithTag("instructBu");
    }

    public void exitInstruct()
    {
        Destroy(this);
        Destroy(pieces[1]);
        Destroy(piecesB[1]);
    }
}
