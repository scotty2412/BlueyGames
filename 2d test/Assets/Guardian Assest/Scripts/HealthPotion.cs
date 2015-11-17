using UnityEngine;
using System.Collections;

public class HealthPotion : MonoBehaviour {

    public int healAmount = 0;
    PlayerHealth health;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            health = hit.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.heal(healAmount);
            }
            Destroy(this.gameObject);
        }
    }
}
