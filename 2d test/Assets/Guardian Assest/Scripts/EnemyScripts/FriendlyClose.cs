using UnityEngine;
using System.Collections;

public class FriendlyClose : MonoBehaviour 
{

    private EnemyChase enemy;



    
	// Use this for initialization
	void Start () 
    {

        enemy = gameObject.GetComponentInParent<EnemyChase>();
	}
	
	// Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            enemy.friendClose = true;
        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            enemy.friendClose = true;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            enemy.friendClose = false;
        }
    }
}
