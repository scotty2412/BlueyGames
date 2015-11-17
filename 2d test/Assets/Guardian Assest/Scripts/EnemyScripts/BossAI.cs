using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour 
{
    GameObject player;
    Rigidbody rigid_body;

    public float delay = 0f;
    public float delayTime = 0f;
    public float playerRange = 0f;
    public float chargeSpeed = 0f;
   
    public bool attacking = false;
    public bool damaged = false;
    public bool inRange = false;
    public bool isGround = true;
    public bool onGround = true;
    
	// Use this for initialization
	void Start () 
    {
	    player = GameObject.FindGameObjectWithTag("Player");
        rigid_body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (((player.transform.position.x - transform.position.x) < playerRange) || ((player.transform.position.x - transform.position.x) < -playerRange))
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (inRange == true)
        {
            if (attacking == false)
            {
                if (player.transform.position.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            delay += Time.deltaTime;
            if(delay > delayTime)
            {
                attacking = true;
                if (isGround == true)
                {
                    rigid_body.velocity = new Vector3((chargeSpeed * rigid_body.transform.localScale.x), 0, 0);
                }
                else if(isGround == false)
                {
                    delay = 0f;
                }
            }
            if(rigid_body.velocity.x == 0)
            {
                attacking = false;
            }
        }
	}

}
