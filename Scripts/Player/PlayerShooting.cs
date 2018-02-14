//Jean-Luc Hayes 11/29/15
//Managers the player's shooting abilities
//If dead - disables shooting effects
using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    private int damagePerShot = 5;
    private float timeBetweenBullets = 0.15f;
    private float range = 100f;
    private float effectsDisplayTime = 0.2f;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    Light gunLight;

    // Use this for initialization
    void Awake ()
    {
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponentInChildren<LineRenderer>();
        gunLight = GetComponentInChildren<Light>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects(false);
        }
    }

    public void DisableEffects(bool effects)
    {
        gunLine.enabled = effects;
        gunLight.enabled = effects;
    }

    void Shoot()
    {
        timer = 0f;

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
