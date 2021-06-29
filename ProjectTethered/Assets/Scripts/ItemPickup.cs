using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
	public Sprite[] itemImages;
	public int itemType;  // 0 = nothing , 1 = Sword , 2 = Axe , 3 = Key 
	private GameObject mesText;
	private string itemName;
	private bool overlapping;
	private GameObject chosenPlayer;
	private GameObject playerCont;
	private AudioSource source;
	public AudioClip pickupSFX;
	private bool coStarted;
	public GameObject spawnText; 

	void Start()
	{
		source = GetComponent<AudioSource>();
		playerCont = GameObject.Find("PlayerController");
		//mesText = GameObject.Find("PlayerMessagePickups").GetComponent<Text>();
		overlapping = false;
		coStarted = false; 

		switch (itemType)
		{
			case 0:
				GetComponent<SpriteRenderer>().sprite = itemImages[0];
				itemName = " ";
				break;
			case 1:
				GetComponent<SpriteRenderer>().sprite = itemImages[1];
				itemName = "Pick up Sword?";
				break;
			case 2:
				GetComponent<SpriteRenderer>().sprite = itemImages[2];
				itemName = "Pick up Axe?";
				break;
			case 3:
				GetComponent<SpriteRenderer>().sprite = itemImages[3];
				itemName = "Pick up Key?";
				break;
		}
	}

	void Update()
	{
		if(itemType == 0)
		{
			if (!coStarted)
			{
				coStarted = true; 
				StartCoroutine(WaitToDestroy());
			}
		}

		if (overlapping && chosenPlayer.name == "PlayerWASD" && Input.GetKeyDown("e"))
		{
			ObtainWeapon();
		}

		if (overlapping && chosenPlayer.name == "PlayerArrow" && Input.GetKeyDown(KeyCode.RightControl))
		{
			ObtainWeapon();
		}
	}

	void ObtainWeapon()
	{
		source.PlayOneShot(pickupSFX);
		if (chosenPlayer.name == "PlayerArrow")
		{
			int tempItem = playerCont.GetComponent<PlayerController>().arrowItem;
			playerCont.GetComponent<PlayerController>().arrowItem = itemType;
			GameObject spawned; 

			switch (itemType)
			{
				case 0: 
					break;
				case 1:
					spawned = Instantiate(spawnText, chosenPlayer.transform);
					spawned.GetComponent<TextMesh>().text = "Sword obtained!"; 
					break; 
				case 2:
					spawned = Instantiate(spawnText, chosenPlayer.transform);
					spawned.GetComponent<TextMesh>().text = "Axe obtained!";
					break; 
				case 3:
					spawned = Instantiate(spawnText, chosenPlayer.transform);
					spawned.GetComponent<TextMesh>().text = "Key obtained!";
					break; 
			}

			itemType = tempItem;
		}

		if (chosenPlayer.name == "PlayerWASD")
		{
			int tempItem = playerCont.GetComponent<PlayerController>().wasdItem;
			playerCont.GetComponent<PlayerController>().wasdItem = itemType;
			GameObject spawned;

			switch (itemType)
			{
				case 0:
					break;
				case 1:
					spawned = Instantiate(spawnText, chosenPlayer.transform);
					spawned.GetComponent<TextMesh>().text = "Sword obtained!";
					break;
				case 2:
					spawned = Instantiate(spawnText, chosenPlayer.transform);
					spawned.GetComponent<TextMesh>().text = "Axe obtained!";
					break;
				case 3:
					spawned = Instantiate(spawnText, chosenPlayer.transform);
					spawned.GetComponent<TextMesh>().text = "Key obtained!";
					break;
			}

			itemType = tempItem;
		}

		switch (itemType)
		{
			case 0:
				GetComponent<SpriteRenderer>().sprite = itemImages[0];
				itemName = " ";
				break;
			case 1:
				GetComponent<SpriteRenderer>().sprite = itemImages[1];
				itemName = "Pick up Sword?";
				break;
			case 2:
				GetComponent<SpriteRenderer>().sprite = itemImages[2];
				itemName = "Pick up Axe?";
				break;
			case 3:
				GetComponent<SpriteRenderer>().sprite = itemImages[3];
				itemName = "Pick up Key?";
				break;
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.transform.GetChild(1).GetComponent<TextMesh>().text = "" + itemName;
			overlapping = true;
			chosenPlayer = col.gameObject;
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			chosenPlayer = null;
			overlapping = false;
			col.transform.GetChild(1).GetComponent<TextMesh>().text = ""; 
		}
	}

	IEnumerator WaitToDestroy()
	{
		chosenPlayer.transform.GetChild(1).GetComponent<TextMesh>().text = "";
		yield return new WaitForSeconds(1);
		Destroy(gameObject); 
	}
}
