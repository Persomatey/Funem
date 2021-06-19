using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
	public bool pressed;

	public Sprite platePressed;
	public Sprite plateUnpressed;

	public AudioSource source;
	public AudioClip plateSFX; 

	private void Start()
	{
		gameObject.AddComponent<AudioSource>();
		source = GetComponent<AudioSource>();
		plateSFX = GameObject.Find("PlayerController").GetComponent<PlayerController>().plateSFX;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			source.PlayOneShot(plateSFX); 
			pressed = true;
			GetComponent<SpriteRenderer>().sprite = platePressed; 
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			pressed = false;
			GetComponent<SpriteRenderer>().sprite = plateUnpressed;
		}
	}
}
