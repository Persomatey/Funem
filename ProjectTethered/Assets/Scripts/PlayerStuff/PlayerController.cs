using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public GameObject wasd;
	public GameObject arrow;
	//private GameObject ropeMeterImg;
	private GameObject ropeMeterFillImg;
	int curRopeExt; 
	public Sprite[] ropeMeterArr;
	private const int maxRopeExt = 10;
	private float curDistance; 
	private float maxDistance;
	public Sprite ropeFull;
	public Sprite ropeLoose;

	public int wasdItem;	// 0 = nothing , 1 = sword , 2 = Axe , 3 = Key 
	public int arrowItem; 
	private SpriteRenderer wasdItemImg;
	private SpriteRenderer arrowItemImg;
	public Sprite[] itemImages;
	public GameObject swordPrefab; 
	public bool swordSwingingWasd;
	public bool swordSwingingArro;
	public bool canChopTree;
	public GameObject chosenTree;
	public bool canOpenDoor;
	public GameObject chosenDoor;

	public int health;
	private const int maxHealth = 3; 
	private Image heart1;
	private Image heart2;
	private Image heart3;
	public Sprite heartFull;
	public Sprite heartEmpty;
	public GameObject mainCanvas;
	public GameObject pauseCanvas;
	public GameObject deathCanvas;

	private AudioSource source;
	public AudioClip playerHit;
	public AudioClip nothingEquippedSFX;
	public AudioClip plateSFX;
	public AudioClip itemSwapSFX;
	public AudioClip RopeExtensionSFX;
	public AudioClip selectionSFX;
	public AudioClip pauseSFX; 

	public GameObject swapImgWasd;
	public GameObject swapImgArro;

	private bool swappable;
	private float swapSpeed; 


	void Start()
	{
		curRopeExt = 5; 
		//ropeMeterImg = GameObject.Find("RopeMeterImg");
		ropeMeterFillImg = GameObject.Find("RopeMeterFillImg");
		arrow = GameObject.Find("PlayerArrow");
		wasd = GameObject.Find("PlayerWASD");
		wasdItemImg = GameObject.Find("WasdItem").GetComponent<SpriteRenderer>(); 
		arrowItemImg = GameObject.Find("ArrowItem").GetComponent<SpriteRenderer>();
		source = GetComponent<AudioSource>();
		wasdItem = 0;
		arrowItem = 0;
		swordSwingingWasd = false;
		swordSwingingArro = false;
		swappable = false;
		swapSpeed = 0.5f; 

		health = maxHealth;
		heart1 = GameObject.Find("Heart1").GetComponent<Image>();
		heart2 = GameObject.Find("Heart2").GetComponent<Image>();
		heart3 = GameObject.Find("Heart3").GetComponent<Image>();

		swapImgArro = GameObject.Find("SwapImgArro"); 
		swapImgWasd = GameObject.Find("SwapImgWasd");
	}

	private void Update()
	{
		UpdateHearts();
		SwapItems();
		RopeLength();
		ItemUsage();
		CheckHealth();
		PauseListener();
	}

	void FixedUpdate()
	{
		SwapItemsAnimation(); 
	}

	void PauseListener()
	{
		if(Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale == 0)
			{
				source.PlayOneShot(selectionSFX);

				mainCanvas.SetActive(true);
				pauseCanvas.SetActive(false);
				deathCanvas.SetActive(false);
				Time.timeScale = 1; 
			}
			else if (Time.timeScale != 0)
			{
				source.PlayOneShot(pauseSFX);

				mainCanvas.SetActive(false);
				pauseCanvas.SetActive(true);
				deathCanvas.SetActive(false);
				Time.timeScale = 0;
			}
		}
	}

	void ItemUsage()
	{
		switch (wasdItem)
		{
			case 0:
				wasdItemImg.sprite = itemImages[0];
				break;
			case 1:
				wasdItemImg.sprite = itemImages[1];
				break;
			case 2:
				wasdItemImg.sprite = itemImages[2];
				break;
			case 3:
				wasdItemImg.sprite = itemImages[3];
				break;
		}

		switch (arrowItem)
		{
			case 0:
				arrowItemImg.sprite = itemImages[0];
				break;
			case 1:
				arrowItemImg.sprite = itemImages[1];
				break;
			case 2:
				arrowItemImg.sprite = itemImages[2];
				break;
			case 3:
				arrowItemImg.sprite = itemImages[3];
				break;
		}

		if (Input.GetKeyDown(KeyCode.RightShift))
		{
			switch (arrowItem)
			{
				case 0:
					source.PlayOneShot(nothingEquippedSFX); 
					Debug.Log("Arrow not holing item");

					break;
				case 1:
					if (!swordSwingingArro)
					{
						Debug.Log("Arrow uses Sword");
						swordSwingingArro = true;
						Instantiate(swordPrefab, arrow.transform);
					}
					else
					{
						Debug.Log("Arrow already using Sword");
					}
					break;
				case 2:
					if (canChopTree)
					{
						Debug.Log("Arrow uses Axe");
						chosenTree.GetComponent<Tree>().Chop();
					}
					else
					{
						Debug.Log("No Tree to Chop");
					}
					break;
				case 3:
					if (canOpenDoor)
					{
						Debug.Log("Arrow uses Key");
						chosenDoor.GetComponent<KeyDoor>().Open();
						arrowItem = 0;
					}
					else
					{
						Debug.Log("No Door to Open");
					}
					break;
			}
		}

		if (Input.GetKeyDown("q"))
		{
			switch (wasdItem)
			{
				case 0:
					source.PlayOneShot(nothingEquippedSFX);
					Debug.Log("Wasd not holing item");
					break;
				case 1:
					if (!swordSwingingWasd)
					{
						Debug.Log("Wasd uses Sword");
						swordSwingingWasd = true;
						Instantiate(swordPrefab, wasd.transform);
					}
					else
					{
						Debug.Log("Wasd already using Sword");
					}
					break;
				case 2:
					if (canChopTree)
					{
						Debug.Log("Wasd uses Axe");
						chosenTree.GetComponent<Tree>().Chop();
					}
					else
					{
						Debug.Log("No Tree to Chop");
					}
					break;
				case 3:
					if (canOpenDoor)
					{
						Debug.Log("Wasd uses Key");
						chosenDoor.GetComponent<KeyDoor>().Open();
						wasdItem = 0;
					}
					else
					{
						Debug.Log("No Door to Open");
					}
					break;
			}
		}
	}

	void RopeLength()
	{
		curDistance = Vector3.Distance(arrow.transform.position, wasd.transform.position);
		maxDistance = arrow.GetComponent<SpringJoint2D>().distance;

		if (curDistance >= maxDistance)
		{
			ropeMeterFillImg.GetComponent<Image>().sprite = ropeFull;
			ropeMeterFillImg.GetComponent<RectTransform>().localScale = new Vector3(10, 10, 1);
		}
		else
		{
			ropeMeterFillImg.GetComponent<Image>().sprite = ropeLoose;
			ropeMeterFillImg.GetComponent<RectTransform>().localScale = new Vector3((curDistance / maxDistance) * 10, 10, 1);
		}
	}

	void SwapItems()
	{
		if (Input.GetKeyDown("space"))
		{
			source.PlayOneShot(itemSwapSFX); 
			int tempItem = wasdItem;
			wasdItem = arrowItem;
			arrowItem = tempItem;

			// swap animation stuff 
			swapImgWasd.GetComponent<SpriteRenderer>().sprite = wasdItemImg.sprite;
			swapImgArro.GetComponent<SpriteRenderer>().sprite = arrowItemImg.sprite;

			swapImgWasd.transform.parent = null;
			swapImgArro.transform.parent = null;

			swappable = true;
		}
	}

	void SwapItemsAnimation()
	{
		if(swappable)
		{
			wasdItemImg.transform.localScale = new Vector3(0,0,1); 
			arrowItemImg.transform.localScale = new Vector3(0,0,1);

			swapImgWasd.transform.position = Vector3.MoveTowards(swapImgWasd.transform.position, arrow.transform.position, swapSpeed); 
			swapImgArro.transform.position = Vector3.MoveTowards(swapImgArro.transform.position, wasd.transform.position, swapSpeed);

			if (swapImgWasd.transform.position == arrow.transform.position)
			{
				swappable = false; 
			}
		}
		else
		{
			swapImgWasd.transform.parent = wasd.transform;
			swapImgArro.transform.parent = arrow.transform;

			swapImgWasd.transform.localPosition = new Vector3(0,0,0); 
			swapImgArro.transform.localPosition = new Vector3(0,0,0);

			swapImgWasd.GetComponent<SpriteRenderer>().sprite = null;
			swapImgArro.GetComponent<SpriteRenderer>().sprite = null;
			wasdItemImg.transform.localScale = new Vector3(0.5f, 0.5f, 1);
			arrowItemImg.transform.localScale = new Vector3(0.5f, 0.5f, 1);
		}
	}

	void UpdateHearts()
	{
		switch(health)
		{
			case 0:
				heart1.sprite = heartEmpty;
				heart2.sprite = heartEmpty;
				heart3.sprite = heartEmpty;
				break;
			case 1:
				heart1.sprite = heartFull;
				heart2.sprite = heartEmpty;
				heart3.sprite = heartEmpty;
				break;
			case 2:
				heart1.sprite = heartFull;
				heart2.sprite = heartFull;
				heart3.sprite = heartEmpty;
				break;
			case 3:
				heart1.sprite = heartFull;
				heart2.sprite = heartFull;
				heart3.sprite = heartFull;
				break; 
		}
	}

	void CheckHealth()
	{
		if(health > maxHealth)
		{
			health = maxHealth; 
		}

		if(health <= 0)
		{
			health = 0;
			DeathState(); 
		}
	}

	void DeathState()
	{
		mainCanvas.SetActive(false);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(true);

		Time.timeScale = 0; 
	}

	public void TakeDamage(int dam)
	{
		source.PlayOneShot(playerHit); 
		health -= dam; 
	}

	public void ChangeRopeMeterSizes()
	{
		if (curRopeExt < maxRopeExt)
		{
			source.PlayOneShot(RopeExtensionSFX);
			curRopeExt++;
			int curRopeTemp = curRopeExt - 5;

			Debug.Log("Rope Extended to " + curRopeExt);
		}
		else
		{
			Debug.Log("Can't extend rope any more!");
		}
	}
}
