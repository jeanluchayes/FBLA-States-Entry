//Jean-Luc Hayes 02/02/16
//WayPoint Manager
//Makes sure that the Waypoints are the current one when a player dies
using UnityEngine;
using System.Collections;

public class WayPoints : MonoBehaviour
{
    public GameObject[] wayPoints = new GameObject[14];
    public WaypointLocate wayPointLocate;
    private GameObject player;
    private PlayerHealth playerHealth;

    private bool lastWayPoint = false;
    public Canvas canvas;
    public UnityEngine.UI.Text hitWayPoint;

    public int wayPoint = 0;
    private float minDist;

    public bool getLastWayPoint()
    {
        return lastWayPoint;
    }
    public void setLastWayPoint(bool way)
    {
        lastWayPoint = way;
    }

	// Use this for initialization
	void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        if (player != null)
        {
            if (playerHealth.CurrentHealth > 0 && wayPoint < wayPoints.Length)
            {
                wayPointLocate.locate(wayPoints[wayPoint]);
                if (closeEnough(player, wayPoints[wayPoint]) <= 8f)
                {
                    UnityEngine.UI.Text hitWayPoints = Instantiate(hitWayPoint, hitWayPoint.transform.position, Quaternion.Euler(Vector3.zero)) as UnityEngine.UI.Text;
                    hitWayPoints.transform.SetParent(canvas.transform, false);
                    Destroy(hitWayPoints, 1f);
                    wayPoint++;
                }
            }
            if (wayPoint == wayPoints.Length)
            {
                lastWayPoint = true;
            }
        }
	}

    public void setPreviousLife()
    {
        wayPoint = LevelManager.wayPoint;
    }

    public static float closeEnough(GameObject player, GameObject wayPoints)
    {
        return Vector3.Distance(player.transform.position, wayPoints.transform.position);
    }
    public static float closeEnough(GameObject player, Transform wayPoints)
    {
        return Vector3.Distance(player.transform.position, wayPoints.transform.position);
    }
}
