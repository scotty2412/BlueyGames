using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour 
{

    public Sprite[] HeartSprites;

    public Image HeartsUI;

    private PlayerHealth player;
    
	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    HeartsUI.sprite = HeartSprites[player.currentHealth - 1];
	}
}
