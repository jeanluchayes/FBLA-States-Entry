//Jean-Luc Hayes 01/31/16
//Finds the angle between the arrow and the next waypoint
//if close enough to the waypoint, set nextwayPoint.
using UnityEngine;
using System.Collections;

public class WaypointLocate : MonoBehaviour
{
    public GameObject target = null;
    public static bool nextWayPoint = false;
    private GameObject nextWayPoints = null;

	// Use this for initialization
	void Awake ()
    {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (nextWayPoint == true)
        {
            float angle = signedAngle(nextWayPoints, Camera.main);
			//interpret the angle change slowly.
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(90, angle, 0), 0.1f);
        }
        if (target)
        {
            float angle = signedAngle(target, Camera.main);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(90, angle, 0), 0.1f);
        }
    }

    public static float signedAngle(GameObject wayPoints, Camera camera)
    {
        Vector3 dist = calcDist(wayPoints, camera);
        float angle = calcAngle(dist, camera);
        Vector3 cross = Vector3.Cross(dist, camera.transform.forward);
        if (cross.y < 0)
        {
            angle = -angle;
        }
        return angle;
    }

    public static float calcPoint(GameObject waypoint, Camera camera)
    {
        Vector3 dist = calcDist(waypoint, camera);
        float angle = calcAngle(dist, camera.transform.forward);
        return angle;
    }

    public static float calcAngle(Vector3 target, Vector3 orig)
    {
        return Vector3.Angle(target, orig);
    }

    public static float calcAngle(Vector3 target, Camera camera)
    {
        return Vector3.Angle(target, camera.transform.forward);
    }

    public static Vector3 calcDist(GameObject target, Camera orig)
    {
        return target.transform.position - orig.transform.position;
    }

    public void locate(GameObject wayPoint)
    {
        nextWayPoint = true;
        nextWayPoints = wayPoint;
    }
}
