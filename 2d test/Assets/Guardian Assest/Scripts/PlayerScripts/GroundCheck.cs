using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour 
{
    private GuyMove player;

    void Start()
    {
        player = gameObject.GetComponentInParent<GuyMove>();
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            player.onGround = true;
        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            player.onGround = true;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        
        player.onGround = false;
        
    }

}
