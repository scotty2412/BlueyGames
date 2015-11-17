using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
    public int startingHealth = 6;
    public int currentHealth;
    public bool healthBuffer = false;
    public float buffer = 0f;


    Rigidbody rigid_body;
    GuyMove guy;

    private int amount = 0;
	// Use this for initialization
	void Start () 
    {
        currentHealth = startingHealth;
        rigid_body = GetComponentInParent<Rigidbody>();
        guy = gameObject.GetComponentInParent<GuyMove>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(healthBuffer == true)
        {
            buffer += Time.deltaTime;
            if (buffer > .2)
            {
                healthBuffer = false;
                buffer = 0f;
            }
        }
        if(currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
       
        if (currentHealth == 1)
        {
            guy.dead = true;
            rigid_body.constraints = RigidbodyConstraints.None;
            rigid_body.constraints = RigidbodyConstraints.FreezePositionZ;
            if (amount == 0)
            {
                rigid_body.velocity = new Vector3(-rigid_body.transform.localScale.x * 4, 2, 0);

                amount++;
            }

        }
	}

    public void dealPlayerDamage()
    {
        if (guy.damaged == false)
        {
            currentHealth -= 1;
            guy.damaged = true;
        }
    }

    public void heal(int amount)
    {
        if (healthBuffer == false)
        {
            currentHealth += amount;
            healthBuffer = true;
        }
    }

}
