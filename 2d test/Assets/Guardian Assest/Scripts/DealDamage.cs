using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {

    GameObject enemy;
    EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            enemyHealth = hit.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.dealDamage();

            }
            Destroy(this.gameObject);
        }
    }
}
