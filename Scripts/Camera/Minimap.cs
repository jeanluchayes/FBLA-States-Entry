//Jean-Luc Hayes 01/31/16
//used to make the Minimap follow the movement of the Player
using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour
{
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
	}
}
