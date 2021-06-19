using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
	public Sprite keySprite;
	private AudioSource source;
	public AudioClip doorSFX;
	public bool isColliding;

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			GameObject.Find("PlayerController").GetComponent<PlayerController>().canOpenDoor = true;
			GameObject.Find("PlayerController").GetComponent<PlayerController>().chosenDoor = gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			GameObject.Find("PlayerController").GetComponent<PlayerController>().canOpenDoor = false;
			GameObject.Find("PlayerController").GetComponent<PlayerController>().chosenDoor = null;
		}
	}

	public void Open()
	{
		source.PlayOneShot(doorSFX);
		StartCoroutine(OpenAnim());
	}

	IEnumerator OpenAnim()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = keySprite;
		yield return new WaitForSeconds(0.15f);
		gameObject.GetComponent<SpriteRenderer>().flipX = true;
		yield return new WaitForSeconds(0.15f);
		Destroy(gameObject);
	}
}
