//Jean-Luc Hayes 11/27/15
//Attack manager for an enemy
//Detects collisions and attacks if colider is a person
using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 1.0f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    public bool playerInFront;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    float timer;
    private bool isBoss = false;

    public bool IsBoss
    {
        get { return isBoss; }
        set{isBoss = value; }
    }
    public float TimeBetweenAttacks
    {
        get{ return timeBetweenAttacks; }
        set{ timeBetweenAttacks = value; }
    }
    public int AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }

    // Use this for initialization
    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenAttacks && playerInFront && enemyHealth.CurrentHealth > 0)
        {
            Attack();
            timer = 0;
        }
        /*if (LevelManager.bossBattleStarted == true)
        {
            timeBetweenAttacks = bossBattle.TimeBetweenAttacks;
            attackDamage = bossBattle.AttackDamage;
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInFront = true;
            anim.SetBool("PlayerInFront", playerInFront);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInFront = false;
            anim.SetBool("PlayerInFront", playerInFront);
        }
    }

    void Attack()
    {

        if (playerHealth.CurrentHealth > 0)
        {
            playerHealth.takeDamage(attackDamage);
        }
    }
}