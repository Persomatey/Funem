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

	void Start()
	{
		Time.timeScale = 1;
	}

	void Update()
	{
		if (plateA.GetComponent<Plate>().pressed)
		{
			Destroy(doorA);
		} 

		if (plateWin1.GetComponent<Plate>().pressed && plateWin2.GetComponent<Plate>().pressed)
		{
			CompleteLevel();
		}
	}

	void CompleteLevel()
	{
		mainCanvas.SetActive(false);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(false);
		winCanvas.SetActive(true);

		Time.timeScale = 0;
	}
}
