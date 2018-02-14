//Jean-Luc Hayes 11/28/15
//Controls the movement of Player
//many booleans to detect the state of the animation of the player
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //public static bool inFront = false;
    private float walkingSpeed = 8f;
    private float runningSpeed = 12f;
    private float rotateSpeed = 5;

    public float fadeTime = 0.5f;
    private float timer;

    private bool walking;
    private bool running;
    private bool standing;
    private bool strafeRight;
    private bool strafeLeft;
    private bool jumping;
    public AudioClip[] sounds = new AudioClip[2];

    Animation anim;

    //Inizilation of Game
    void Awake()
    {
        anim = GetComponent<Animation>();
        //checkPosition();
    }

    // Update is not called once per frame, but evenly for all frame rates
    void FixedUpdate()
    {
        //timer = 0;
        timer += Time.deltaTime;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        walking = h != 0f || v != 0f;
        standing = !walking;
        strafeRight = h > 0f;
        strafeLeft = h < 0f;
        running = Input.GetKey(KeyCode.LeftShift);
        standing = Input.GetMouseButton(0);

        //Turn();
        Move(h, v);
        Animating(h, v);
    }

    public void setPreviousLife()
    {
        transform.position = LevelManager.deathPoint;
        ScoreManager.score = LevelManager.score;
    }

    void Move(float h, float v)
    {
        if (walking)
        {
            moveFoward(walkingSpeed, h, v);
        }
        if (running)
        {
            moveFoward(runningSpeed, h, v);
        }
    }

    void moveFoward(float speed, float h, float v)
    {
        //InvokeRepeating("footsteps", 0, 1f);
        transform.position += transform.forward * v * speed * Time.deltaTime;
        transform.position += transform.right * h * speed * Time.deltaTime;
    }

    /*void gunshot()
    {
        AudioSource.PlayClipAtPoint(sounds[1], transform.position);
    }*/

    /*void footsteps()
    {
        AudioSource.PlayClipAtPoint(sounds[0], transform.position);
    }*/

    void moveUpward(float height)
    {
        transform.position += transform.up * height;
    }

    void Animating(float h, float v)
    {
        anim.CrossFade("soldierIdleRelaxed", fadeTime);
        if (walking)
        {
            anim.CrossFade("soldierWalk", fadeTime);
        }
        if (standing)
        {
            //InvokeRepeating("gunshot", 0, 1f);
            anim.CrossFade("soldierIdle", fadeTime);
        }
        if (running)
        {
            anim.CrossFade("soldierSprint", fadeTime);
        }
        if (strafeRight)
        {
            anim.CrossFade("soldierStrafeRight", fadeTime);
        }
        if (strafeLeft)
        {
            anim.CrossFade("soldierStrafeLeft", fadeTime);
        }
     }

    void Turn()
    {           
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f; ;
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }        
}
