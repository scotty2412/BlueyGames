using UnityEngine;
using System.Collections;

public class BossGroundCheck : MonoBehaviour {

    GameObject player;
    private BossAI enemy;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = gameObject.GetComponentInParent<BossAI>();
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (enemy.onGround == true)
        {

            if ((Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f)) == false)
            {
                if (hit.collider.tag == "ground")
                {
                    enemy.isGround = false;
                }
            }
            else
            {

                if (hit.collider.tag == "ground")
                {
                    enemy.isGround = true;
                }
            }
        }
    }
}
