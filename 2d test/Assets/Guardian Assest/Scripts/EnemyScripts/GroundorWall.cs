using UnityEngine;
using System.Collections;

public class GroundorWall : MonoBehaviour 
{
    GameObject player;
    private EnemyChase enemy;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = gameObject.GetComponentInParent<EnemyChase>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        
         //////////////////No jump system
        
    
        RaycastHit hit;
        //Ray landingRay = new Ray(transform.position, dDir);
        if (enemy.onGround == true)
        {

            if((Physics.Raycast(transform.position, Vector3.down, out hit)) == false)
            {
           
                    enemy.isGround = false;
                
            }
            else if ((Physics.Raycast(transform.position, Vector3.down, out hit)) == true)
            {


                    enemy.isGround = true;
                
            }
        }
        Debug.DrawLine(transform.position, -Vector3.up, Color.red);
         
        //Work on this for jump
        /*
        Vector3 dDir;
        if (player.transform.position.x < transform.position.x)
        {
            dDir = Quaternion.AngleAxis(-160.0f, Vector3.forward) * transform.right;

        }
        else
        {
            dDir = Quaternion.AngleAxis(-60.0f, Vector3.forward) * transform.right;
        }

        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, dDir);
        if (enemy.onGround == true)
        {

            if ((Physics.Raycast(landingRay, out hit, 5f)) == false)
            {
                enemy.isGround = false;
            }
            else
            {
                enemy.isGround = true;
            }
        }
         **/
	}
}
