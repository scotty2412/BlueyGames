using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

    GameObject player;

    public float speed = 0f;
    public float maxSpeed = 0f;
    public float jumpPower = 0f;
    public float jumpSpeed = 0f;
    public int bounce = 0;
    public int bounceDirection = 0;
    public float playerRange = 0f;


    Rigidbody rigid_body;
    float groundTimer = 0f;
    public float Timer = 0f;


    public bool inRange = false;
    public bool onGround = false;
    public bool isGround = false;
    public bool friendClose = false;
    public bool dead = false;
    public bool damaged = false;

	// Use this for initialization
	void Start () 
    {

        player = GameObject.FindGameObjectWithTag("Player");
        rigid_body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (dead == false)
        {
            Vector3 easeVelocity = rigid_body.velocity;
            easeVelocity.y = rigid_body.velocity.y;
            easeVelocity.z = 0.0f;
            easeVelocity.x *= 1.0f;
            if (damaged == false)
            {
                if (onGround)
                {
                    rigid_body.velocity = easeVelocity;
                }
                if (((player.transform.position.x - transform.position.x) < playerRange) || ((player.transform.position.x + transform.position.x) < -playerRange))
                {
                    if (player.transform.position.x < transform.position.x)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    if (onGround == true && isGround == true && friendClose == false && damaged == false)
                    {
                        Vector2 velocity = new Vector2((transform.position.x - player.transform.position.x) * speed, 0);
                        rigid_body.AddForce(-velocity);
                    }
                }
            }
            else if(damaged == true)
            {
                Timer += Time.deltaTime;
                if (Timer < .5)
                {
                    rigid_body.velocity = new Vector2(-(bounce * rigid_body.transform.localScale.x), bounce);
                }
                else if (Timer > .5)
                {
                    Timer = 0;
                    damaged = false;
                }
            }
            //Work on for jumping
                /*
            else if (onGround == true && isGround == false)
            {
                Vector2 velocity = new Vector2((transform.position.x - player.transform.position.x) * speed, -jumpPower);
               rigid_body.AddForce(-velocity);
            }
             */
            if (rigid_body.velocity.x > maxSpeed)
            {
                rigid_body.velocity = new Vector2(maxSpeed, rigid_body.velocity.y);
            }
            if (rigid_body.velocity.x < -maxSpeed)
            {
                rigid_body.velocity = new Vector2(-maxSpeed, rigid_body.velocity.y);
            }
        }
 
	}


    void OnTriggerStay(Collider hit)
    {
        groundTimer += Time.deltaTime;
        if (groundTimer >= .5f)
        {
            onGround = true;
          
        }
    }

    void OnTriggerExit(Collider hit)
    {
        groundTimer = 0;
        onGround = false;
    }
}
