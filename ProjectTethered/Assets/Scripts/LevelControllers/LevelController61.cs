using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController61 : MonoBehaviour
{
	[Header("Canvases")]
	public GameObject mainCanvas;
	public GameObject pauseCanvas;
	public GameObject deathCanvas;
	public GameObject winCanvas;

	[Header("Plates")]
	public GameObject plateA;

	[Header("Door")]
	public GameObject doorA;

	[Header("Win Conditions")]
	public GameObject plateWin1;
	public GameObject plateWin2;

	[Header("SFX")]
	private AudioSource source;
	public AudioClip victorySFX;

	private bool completeOnce;

	void Start()
	{
		Time.timeScale = 1;

		completeOnce = false;
		gameObject.AddComponent<AudioSource>();
		source = GetComponent<AudioSource>();

		GameObject.Find("PlayerArrow").transform.position = new Vector3(-0.5f, -5.35f, -5);
		GameObject.Find("PlayerWASD").transform.position = new Vector3(-3.5f, -5.35f, -5);
	}

	void Update()
	{
		if (plateA.GetComponent<Plate>().pressed)
		{
			Destroy(doorA);
		} 

		if (plateWin1.GetComponent<Plate>().pressed && plateWin2.GetComponent<Plate>().pressed)
		{
			if (!completeOnce)
			{
				completeOnce = true;
				CompleteLevel();
			}
		}
	}

	void CompleteLevel()
	{
		mainCanvas.SetActive(false);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(false);
		winCanvas.SetActive(true);

		source.PlayOneShot(victorySFX);

		Time.timeScale = 0;
	}
}
