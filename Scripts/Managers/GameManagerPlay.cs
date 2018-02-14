//Jean-Luc Hayes 01/30/16
//Game Manager Play controls aspects of gameplay integral to gameplay
//Spawns minions and controls spawnTime
using UnityEngine;
using System.Collections;

public class GameManagerPlay : MonoBehaviour
{
    public int waves = 1;
    UnityEngine.UI.Text wave;
    public static float timeLeft = 60;

    public GameObject player;
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 10f;
    public Transform[] spawnPoints;
    private Transform[] spawnPointsClose;

    // Use this for initialization
    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPointsClose = new Transform[4];
        //wave = GetComponent<UnityEngine.UI.Text>();
        //waves = 1;
    }

    void FixedUpdate()
    {
        //wave.text = "Wave: " + waves;
        /*timeLeft -= Time.deltaTime;
        WaveSelector();
        if (timeLeft <= 0)
        {
            waves++;
            timeLeft = 60;
        }*/
        player = GameObject.FindGameObjectWithTag("Player");
        if (Time.deltaTime > 60f || Time.deltaTime > 120f || Time.deltaTime > 240 || Time.deltaTime > 480)
        {
            spawnTime = spawnTime * Mathf.Exp(-0.111f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
	
	void Start ()
    {
        InvokeRepeating("Spawn", 0, spawnTime);
    }
	
	/*void WaveSelector()
	{
        float[] spawnTimes = new float[100];

        for (int i = 0; i < 100; i++)
        {
            float start = 5f;
            spawnTimes[i] = (start / 2.0f);

            if (waves == i)
            {
                spawnTime = spawnTimes[i];
            }
        }
	}*/

    void Spawn()
    {
        if (playerHealth.CurrentHealth <= 0f || LevelManager.bossBattleStarted == true)
        {
            return;
        }
        int j = 0;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (WayPoints.closeEnough(player, spawnPoints[i]) <= 125f && j != 4)
            {
                spawnPointsClose[j] = spawnPoints[i];
                j++;
            }
        }
        int k = Random.Range(0, spawnPointsClose.Length);
        Instantiate(enemy, spawnPointsClose[k].position, spawnPointsClose[k].rotation);
    }
}