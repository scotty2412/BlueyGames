using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour 
{
    public float attackDelay = 0f;
    EnemyHealth enemyHealth;
    EnemyChase enemyChase;
    public bool attack = false;
	// Use this for initialization
	void Start () 
    {
        enemyChase = gameObject.GetComponentInParent<EnemyChase>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
        }
        if(attack == true)
        {
            attackDelay += Time.deltaTime;
            if(attackDelay >= .2f)
            {
                if (enemyHealth != null)
                {
                    enemyHealth.dealDamage();
                    //enemyChase.damaged = true;
                    
                }
                attack = false;
            }
        }
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            enemyHealth = hit.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                
            }

        }
    }

  
}
