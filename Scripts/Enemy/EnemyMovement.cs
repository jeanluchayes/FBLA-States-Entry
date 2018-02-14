//Jean-Luc Hayes 11/28/15
//Controls the movement of an enemy
//Sets destination is the collision is a player
using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    public NavMeshAgent nav;
    Animator anim;

    public bool isBoss = false;

    public bool IsBoss
    {
        get { return isBoss; }
        set { isBoss = value; }
    }

	// Use this for initialization
	void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        if (player != null)
        {
            if (enemyHealth.CurrentHealth > 0 && playerHealth.CurrentHealth > 0 && isBoss == false)
            {
                nav.SetDestination(player.transform.position);
                anim.SetBool("PlayerNoticed", true);
            }
            else
            {
                anim.SetBool("PlayerNoticed", true);
            }
        }
	}

    public void setNavPoint(GameObject target)
    {
        nav.SetDestination(target.transform.position);
    }

    public void setNavPoint(Transform target)
    {
        nav.SetDestination(target.position);
    }
}
