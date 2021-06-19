using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController1 : MonoBehaviour
{
	[Header("Canvases")]
	public GameObject mainCanvas;
	public GameObject pauseCanvas;
	public GameObject deathCanvas;
	public GameObject winCanvas; 

	[Header("Plates")]
	public GameObject plateA;
	public GameObject plateB;
	public GameObject plateC1;
	public GameObject plateC2;

	[Header("Door")]
	public GameObject doorA;
	public GameObject doorB;
	public GameObject doorC;

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

		if (plateB.GetComponent<Plate>().pressed)
		{
			Destroy(doorB);
		}

		if (plateC1.GetComponent<Plate>().pressed && plateC2.GetComponent<Plate>().pressed)
		{
			Destroy(doorC);
		}

		if (plateWin1.GetComponent<Plate>().pressed && plateWin2.GetComponent<Plate>().pressed)
		{
			CompleteLevel(); 
		}
	}

	void CompleteLevel()
	{
		GetComponent<DataReaderWriter>().AmendList(3, "T");
		GetComponent<DataReaderWriter>().WriteData(); 

		mainCanvas.SetActive(false);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(false);
		winCanvas.SetActive(true);

		Time.timeScale = 0;
	}
}
