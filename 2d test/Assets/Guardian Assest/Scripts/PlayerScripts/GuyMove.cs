using UnityEngine;
using System.Collections;

public class GuyMove : MonoBehaviour 
{

    public float jumpSpeed = 0f;
    public float speed = 0f;
    public float maxSpeed = 0f;
    public int bounce = 0;

    public bool onGround = true;

    float Timer = 0f;

    Rigidbody rigid_body;

    public bool dead = false;
    public bool damaged = false;

	// Use this for initialization
	void Start () 
    {
        rigid_body = GetComponent<Rigidbody>();
	}
	
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && onGround && damaged == false)
        {
            rigid_body.AddForce(Vector2.up * jumpSpeed);
        }
    }

	void FixedUpdate () 
    {
        Vector3 easeVelocity = rigid_body.velocity;
        easeVelocity.y = rigid_body.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 1.0f;

        if(onGround)
        {
            rigid_body.velocity = easeVelocity;
        }

        float h;
        h = 0;
        if (Input.GetKey(KeyCode.A) && damaged == false)
        {
            h = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D) && damaged == false)
        {
            h = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        /*       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        */
        if(damaged == true)
            {
                Timer += Time.deltaTime;
                if(Timer < .3)
                {
                  rigid_body.velocity = new Vector2(-(bounce * rigid_body.transform.localScale.x), bounce);
                }
                else if(Timer > .3)
                {
                    Timer = 0;
                    damaged = false;
                }
            }
        rigid_body.AddForce((Vector2.right * speed) * h);

        if(rigid_body.velocity.x > maxSpeed)
        {
            rigid_body.velocity = new Vector2(maxSpeed, rigid_body.velocity.y);
        }
        if (rigid_body.velocity.x < -maxSpeed)
        {
            rigid_body.velocity = new Vector2(-maxSpeed, rigid_body.velocity.y);
        }
	}

}
