//Jean-Luc Hayes 02/02/16
//Manager of a Boss Battle
//uses previous classes that were put on an enemy
using UnityEngine;
using System.Collections;

public class BossBattle : MonoBehaviour
{
    public GameObject boss;
    private EnemyMovement enemyMovement;
    private EnemyHealth enemyHealth;
    private GameObject player;
    private PlayerHealth playerHealth;
    private LevelManager levelManager;

    float timer;

    public Transform bossPoint;
    public Transform[] minions = new Transform[5];

    public int attackDamage = 20;
    public float timeBetweenAttacks = 10f;

    public int startingHealth = 200;
    public float sinkSpeed = 1.0f;
    public float sinkOffset = 12f;
    public int scoreValue = 150;

    private bool isBoss = true;
    private bool isDead = false;

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    public float TimeBetweenAttacks
    {
        get { return timeBetweenAttacks; }
        set { timeBetweenAttacks = value; }
    }
    public int AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }
    public bool IsBoss
    {
        get { return isBoss; }
        set { isBoss = value; }
    }
    public int StartingHealth
    {
        get { return startingHealth; }
        set { startingHealth = value; }
    }
    public int ScoreValue
    {
        get { return scoreValue; }
        set { scoreValue = value; }
    }
    public float SinkSpeed
    {
        get { return sinkSpeed; }
        set { sinkSpeed = value; }
    }
    public float SinkOffset
    {
        get { return sinkOffset; }
        set { sinkOffset = value; }
    }

    // Use this for initialization
    void Awake()
    {
        GameObject levelman = GameObject.FindGameObjectWithTag("LevelManager");
        levelManager = levelman.GetComponent<LevelManager>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyHealth = GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        InvokeRepeating("startMovement", 0, timeBetweenAttacks * 2);
        //setToBoss();
    }
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        timer += Time.deltaTime;
        if(LevelManager.bossBattleStarted == true)
        {
            if (enemyHealth.IsDead)
            {
                LevelManager.bossBattleStarted = false;
                Death();
            }
        }
	}

    void Death()
    {
        isDead = true;
        levelManager.isDead();
    }

    public void bossBattleStart()
    {
        LevelManager.bossBattleStarted = true;
    }

    void startMovement()
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
                enemyMovement.nav.SetDestination(minions[k].position);
            }
        }
    }
}
