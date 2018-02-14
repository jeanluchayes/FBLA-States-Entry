//Jean-Luc Hayes 11/28/15
//Health for an enemy
//Controls death and damage given to the enemy
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 25;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public float sinkOffset = 10f;
    public int scoreValue = 10;

    Animator anim;
    private bool isDead;
    bool isSinking;
    float timer;
    public bool isBoss = false;

    public bool IsBoss
    {
        get { return isBoss; }
        set { isBoss = value; }
    }
    public bool IsDead
    {
        get{return isDead;}
        set{isDead = value;}
    }
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

    void Awake ()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;

    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (isSinking && timer >= sinkOffset)
        {
            Sink();
        }
    }

    public void takeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        StartSinking();
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
    }

    public void Sink()
    {
        if(isBoss)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            Destroy(gameObject, 2f);
        }
    }
}
