using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
	public Sprite axeSprite;
	private AudioSource source;
	public AudioClip chopSFX;
	public bool isColliding;

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			GameObject.Find("PlayerController").GetComponent<PlayerController>().canChopTree = true;
			GameObject.Find("PlayerController").GetComponent<PlayerController>().chosenTree = gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			GameObject.Find("PlayerController").GetComponent<PlayerController>().canChopTree = false;
			GameObject.Find("PlayerController").GetComponent<PlayerController>().chosenTree = null;
		}
	}

	public void Chop()
	{
		source.PlayOneShot(chopSFX);
		StartCoroutine(ChopAnim()); 
	}

	IEnumerator ChopAnim()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = axeSprite;
		yield return new WaitForSeconds(0.15f);
		gameObject.GetComponent<SpriteRenderer>().flipY = true; 
		yield return new WaitForSeconds(0.15f);
		Destroy(gameObject); 
	}
}
