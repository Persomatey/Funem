using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MainMenuController : MonoBehaviour
{
	public GameObject Level1Button; 
	public GameObject Level2Button; 
	public GameObject Level3Button; 
	public GameObject Level4Button; 
	public GameObject Level5Button; 
	public GameObject Level6Button;
	public AudioClip selectionSFX; 

	void Start()
    {
		GetComponent<DataReaderWriter>().ReadData();

		UnlockButtons(); 
    }

	void UnlockButtons()
	{
		if (!DataReaderWriter.level1)
		{
			Level1Button.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
			Level1Button.GetComponent<Button>().enabled = false;
		}

		if (!DataReaderWriter.level2)
		{
			Level2Button.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
			Level2Button.GetComponent<Button>().enabled = false;
		}

		if (!DataReaderWriter.level3)
		{
			Level3Button.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
			Level3Button.GetComponent<Button>().enabled = false;
		}

		if (!DataReaderWriter.level4)
		{
			Level4Button.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
			Level4Button.GetComponent<Button>().enabled = false;
		}

		if (!DataReaderWriter.level5)
		{
			Level5Button.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
			Level5Button.GetComponent<Button>().enabled = false;
		}

		if (!DataReaderWriter.level6)
		{
			Level6Button.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
			Level6Button.GetComponent<Button>().enabled = false;
		}
	}
}
