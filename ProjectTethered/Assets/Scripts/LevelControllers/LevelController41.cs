using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController41 : MonoBehaviour
{
	[Header("Canvases")]
	public GameObject mainCanvas;
	public GameObject pauseCanvas;
	public GameObject deathCanvas;
	public GameObject winCanvas;

	[Header("Plates")]

	[Header("Door")]

	[Header("Win Conditions")]
	public GameObject plateWin1;
	public GameObject plateWin2;

	void Start()
    {
		Time.timeScale = 1;
	}

    void Update()
    {
		if (plateWin1.GetComponent<Plate>().pressed && plateWin2.GetComponent<Plate>().pressed)
		{
			CompleteLevel();
		}
	}

	void CompleteLevel()
	{
		GetComponent<DataReaderWriter>().AmendList(9, "T");
		GetComponent<DataReaderWriter>().WriteData();

		mainCanvas.SetActive(false);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(false);
		winCanvas.SetActive(true);

		Time.timeScale = 0;
	}
}
