//Jean-Luc Hayes 02/02/16
//Controls the Spawning of the Boss's Minions
//Done every 20 seconds, or the variable minionTime seconds
using UnityEngine;
using System.Collections;

public class MinionManager : MonoBehaviour
{
    public float minionTime = 20f;

    private GameObject player;
    private PlayerHealth playerHealth;
    public GameObject enemy;
    private GameObject boss;
    private Transform[] minions = new Transform[5];

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        boss = GameObject.FindGameObjectWithTag("Boss");
        minions = boss.GetComponent<BossBattle>().minions;
        InvokeRepeating("spawnMinions", 0, minionTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    public void spawnMinions()
    {
        if (player != null)
        {
            if (playerHealth.CurrentHealth <= 0f || LevelManager.bossBattleStarted == false)
            {
                return;
            }
            for (int i = 0; i < minions.Length; i++)
            {
                int k = Random.Range(0, minions.Length);
                Instantiate(enemy, minions[k].transform.position, minions[k].transform.rotation);
            }
        }
    }
}
