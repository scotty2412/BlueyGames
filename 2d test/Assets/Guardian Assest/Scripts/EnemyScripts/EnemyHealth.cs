using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
    public int Health = 3;
    public int currentHealth;
 

    private int amount = 0;
    Rigidbody body;

    GameObject enemy;
    Rigidbody rigid_body;
    EnemyChase chase;
  
	// Use this for initialization
	void Start () 
    {
        currentHealth = Health;
        rigid_body = GetComponentInParent<Rigidbody>();
        chase = gameObject.GetComponentInParent<EnemyChase>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (currentHealth == 0)
        {
            chase.dead = true;
            rigid_body.constraints = RigidbodyConstraints.None;
            rigid_body.constraints = RigidbodyConstraints.FreezePositionZ;
            if (amount == 0)
            {
                rigid_body.velocity = new Vector3(-rigid_body.transform.localScale.x * 4, 2, 0);
       
                amount++;
            }
      
        }
	}

    public void dealDamage()
    {
        currentHealth -= 1;
        chase.damaged = true;
    }
}
