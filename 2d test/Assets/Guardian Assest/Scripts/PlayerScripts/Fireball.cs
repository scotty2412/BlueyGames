using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour 
{
    public GameObject fireballPrefab;
    private Transform myTransform;
    public float propulsionForce;

    GameObject player;

	// Use this for initialization
	void Start () 
    {
        myTransform = transform;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           spawnFireball();
        }
	}

    void spawnFireball()
    {
       GameObject go = (GameObject)Instantiate(fireballPrefab, myTransform.TransformPoint(0.5f, 0, 0), myTransform.rotation);
       Rigidbody rigid_body;
       rigid_body = go.GetComponent<Rigidbody>();
       rigid_body.velocity = new Vector2(10 * player.transform.localScale.x, 0);
    }
}
