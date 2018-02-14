//Jean-Luc Hayes 11/25/15
//used to make an object point at the mouse cursor's position
using UnityEngine;
using System.Collections;

public class GunPoint : MonoBehaviour
{
    float zDistance = 10.0f;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 mousePos = Input.mousePosition;
        transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance)));
    }
}
