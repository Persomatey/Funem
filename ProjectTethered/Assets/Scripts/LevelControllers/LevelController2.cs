using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController2 : MonoBehaviour
{
	[Header("Canvases")]
	public GameObject mainCanvas;
	public GameObject pauseCanvas;
	public GameObject deathCanvas;
	public GameObject winCanvas;

	[Header("Plates")]
	public GameObject plateA;

	[Header("Door")]
	public GameObject doorA1;
	public GameObject doorA2;

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
	}

	void Update()
	{
		if (plateA.GetComponent<Plate>().pressed)
		{
			Destroy(doorA1);
			Destroy(doorA2);
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
		GetComponent<DataReaderWriter>().AmendList(5, "T");
		GetComponent<DataReaderWriter>().WriteData();

		mainCanvas.SetActive(false);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(false);
		winCanvas.SetActive(true);

		source.PlayOneShot(victorySFX);

		Time.timeScale = 0;
	}
}
