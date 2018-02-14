//Jean-Luc Hayes 02/01/16
//Manager for the whole Game - Managers the Loading of the Levels
//also resets Player's position if died
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private GameObject deathManagerObject;
    private GameManagerDeath deathManager;
    private GameObject boss;
    private BossBattle bossBattle;
    private GameObject wayPointObject;
    private WayPoints wayPoints;

    public Canvas canvas;

    public static bool reentryLevel = false;
    public static bool endGame = false;
    public static bool bossBattleStarted = false;

    public static int wayPoint = 0;
    public static Vector3 deathPoint = new Vector3(529, 0, 310);
    public static int numLives = 3;
    public static int score = 0;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
        {
            Destroy(gameObject);
        }
        setUpLinks();
    }

    void setUpLinks()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossBattle = boss.GetComponent<BossBattle>();
        deathManagerObject = GameObject.FindGameObjectWithTag("Respawn");
        deathManager = deathManagerObject.GetComponent<GameManagerDeath>();
        wayPointObject = GameObject.FindGameObjectWithTag("WayPoint");
        wayPoints = wayPointObject.GetComponent<WayPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossBattle = boss.GetComponent<BossBattle>();
        deathManagerObject = GameObject.FindGameObjectWithTag("Respawn");
        deathManager = deathManagerObject.GetComponent<GameManagerDeath>();
        wayPointObject = GameObject.FindGameObjectWithTag("WayPoint");
        wayPoints = wayPointObject.GetComponent<WayPoints>();

        if (wayPoints.getLastWayPoint() == true)
        {
            bossBattle.bossBattleStart();
            wayPoints.setLastWayPoint(false);
        }
        if (reentryLevel == true)
        {
            Application.LoadLevel(Application.loadedLevel);
            Invoke("SetPreviousLife", 0.5f);
            reentryLevel = false;
        }

        if (endGame == true)
        {
            Application.LoadLevel("Level 0");
            endGame = false;
            Destroy(this);
        }
    }

    public void SetPreviousLife()
    {
        playerHealth.setPreviousLife();
        playerMovement.setPreviousLife();
        wayPoints.setPreviousLife();
    }

    void checkPosition()
    {
        deathPoint = player.transform.position;
        numLives = playerHealth.CurrentNumLives;
        score = ScoreManager.score;
        wayPoint = wayPoints.wayPoint;
    }

    public void isDead()
    {
        if (playerHealth.IsDead == true && playerHealth.CurrentNumLives != 0 && !(player.transform.position.y < -5))
        {
            checkPosition();
            deathManager.deathText();
        }
        else if (playerHealth.IsDead == true && playerHealth.CurrentNumLives != 0 && (player.transform.position.y < -5))
        {
            deathManager.deathText();
        }
        else if (playerHealth.IsDead == true && playerHealth.CurrentNumLives == 0)
        {
            deathManager.gameOverText();
        }
        else if (playerHealth.IsDead == false && bossBattle.IsDead)
        {
            deathManager.wonText();
        }

    }
}

