//Jean-Luc Hayes 11/26/15
//Managers Health of PlayerHealth
//Also will call neccessary UI
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private LevelManager levelManager;

    private int startingHealth = 100;
    private int currentHealth;

    public GameObject health;
    Animation anim;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;

    private bool isDead;
    private int startingNumLives = 3;
    private int currentNumLives;
    public AudioClip[] sounds = new AudioClip[2];

    public int StartingHealth
    {
        get { return startingHealth; }
        set { startingHealth = value; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }
    public int CurrentNumLives
    {
        get { return currentNumLives; }
        set { currentNumLives = value; }
    }
    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animation>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
        currentNumLives = startingNumLives;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        health.GetComponentInChildren<UnityEngine.UI.Slider>().value = currentHealth;
        if (transform.position.y < -5)
        {
            deathBelow();
        }
    }

    public void setPreviousLife()
    {
        currentNumLives = LevelManager.numLives;
    }

    public void takeDamage(int amount)
    {
        //damaged();

        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    /*void damaged()
    {
        AudioSource.PlayClipAtPoint(sounds[0], transform.position);
    }*/

    void deathBelow()
    {
        isDead = true;
        levelManager.isDead();
        playerShooting.DisableEffects(!isDead);
        anim.CrossFade("soldierDieBack");
        playerMovement.enabled = !isDead;
        playerShooting.enabled = !isDead;
    }

    void Death()
    {
        isDead = true;
        currentNumLives -= 1;
        levelManager.isDead();
        //AudioSource.PlayClipAtPoint(sounds[1], transform.position);
        playerShooting.DisableEffects(!isDead);
        anim.CrossFade("soldierDieFront");
        playerMovement.enabled = !isDead;
        playerShooting.enabled = !isDead;
    }

    public void rebirth()
    {
        isDead = false;
        //gameResetManager.isDead();
        currentHealth = startingHealth;
        playerShooting.DisableEffects(!isDead);
        anim.CrossFade("soldierIdle");
        playerMovement.enabled = !isDead;
        playerShooting.enabled = !isDead;
    }
}
