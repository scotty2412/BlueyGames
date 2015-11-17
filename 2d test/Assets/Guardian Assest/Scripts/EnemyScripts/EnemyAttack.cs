using UnityEngine;
using System.Collections;

public class EnemyAttack: MonoBehaviour
{
    public float attackDelay = 0f;
    public float secondDelay = 0f;
    PlayerHealth playerHealth;
    public bool attack = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void OnTriggerEnter(Collider hit)
    {
        /*
        if (hit.gameObject.tag == "Player")
        {
            secondDelay += Time.deltaTime;
            playerHealth = hit.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.dealPlayerDamage();
                secondDelay = 0f;

            }
        }
         * */
    }
    void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            attackDelay += Time.deltaTime;
            playerHealth = hit.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                if (attackDelay >= 4.0f)
                {
                    playerHealth.dealPlayerDamage();
                    attackDelay = 0f;
                }

            }
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            attackDelay = 0f;
        }
    }


}
