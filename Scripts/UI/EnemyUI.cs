//01/31/16 Jean-Luc Hayes - Some Help from Online - 
//blog.manapebbles.com/world-space-overlay-camera-in-unity
//Enemy UI compares the game state to the enemy state to
//draw the enemyHealthBar above the enemy
using UnityEngine;
using System.Collections;

public class EnemyUI : MonoBehaviour
{
    private float maxDrawDistance = 100f;
    private EnemyHealth enemyHealth;
    private GameObject player;
    private GameObject canvasObject;
    public Canvas canvas;
    public GameObject healthPrefab;
    private Vector3 worldPos;
    private GameObject wayPointObject;
    private WayPoints wayPoints;
    public AudioClip[] fight = new AudioClip[2];

    public bool isBoss = false;
    private DepthUI depthUI;

    public float panelOffset = 5f;
    private GameObject healthPanel;
    private UnityEngine.UI.Slider healthSlider;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        canvas = canvasObject.GetComponent<Canvas>();
        enemyHealth = GetComponent<EnemyHealth>();

        healthPanel = Instantiate(healthPrefab) as GameObject;
        healthPanel.transform.SetParent(canvas.transform, false);
        healthSlider = healthPanel.GetComponentInChildren<UnityEngine.UI.Slider>();

        depthUI = healthPanel.GetComponent<DepthUI>();
        canvas.GetComponent<ScreenSpaceCanvas>().AddToCanvas(healthPanel);
        wayPointObject = GameObject.FindGameObjectWithTag("WayPoint");
        wayPoints = wayPointObject.GetComponent<WayPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyHealth.IsDead)
        {
            float distance = (worldPos - Camera.main.transform.position).magnitude;
            depthUI.depth = -distance;

            healthSlider.value = enemyHealth.CurrentHealth;

            worldPos = new Vector3(transform.position.x, transform.position.y + panelOffset, transform.position.z);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
            healthPanel.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);

            Vector3 dir = Camera.main.WorldToViewportPoint(transform.position);
            //bool onScreen = dir.z > 0 && dir.x > 0 && dir.x < 1 && dir.y > 0 && dir.y < 1;
            healthPanel.SetActive(true);
            if (!(dir.z > 0 && dir.x > 0 && dir.x < 1 && dir.y > 0 && dir.y < 1) || Vector3.Distance(transform.position, player.transform.position) > maxDrawDistance)
            {
                healthPanel.SetActive(false);
            }
            else if (isBoss && LevelManager.bossBattleStarted == false)
            {
                healthPanel.SetActive(false);
            }
            else if (isBoss && LevelManager.bossBattleStarted == true)
            {
                healthPanel.SetActive(true);
                //AudioSource.PlayClipAtPoint(fight[1], transform.position);
                //AudioSource.PlayClipAtPoint(fight[2], transform.position);
                wayPoints.setLastWayPoint(false);
            }
        }
        else if(enemyHealth.IsDead)
        {
            Destroy(healthPanel);
        }
    }
}
