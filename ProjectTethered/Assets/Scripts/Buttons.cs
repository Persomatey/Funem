using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Buttons : MonoBehaviour
{
	public GameObject mainCanvas;
	public GameObject pauseCanvas;
	public GameObject deathCanvas;
	private float time;
	private AudioSource source;
	public AudioClip selectionSFX;
	public GameObject menuCanvas;
	public GameObject creditsCanvas; 

	private void Start()
	{
		gameObject.AddComponent<AudioSource>();
		source = GetComponent<AudioSource>(); 

		//if (SceneManager.GetActiveScene().name == "MainMenu")
		//{
		//	selectionSFX = GameObject.Find("MainMenuController").GetComponent<MainMenuController>().selectionSFX; 
		//}
		//else
		//{
		//	selectionSFX = GameObject.Find("PlayerController").GetComponent<MainMenuController>().selectionSFX;
		//}

		time = selectionSFX.length; 
	}

	public void ToMainMenu()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(ToMainMenuCo());
	}

	IEnumerator ToMainMenuCo()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}

	public void OpenCredits()
	{
		Time.timeScale = 1;
		source.PlayOneShot(selectionSFX);
		StartCoroutine(OpenCreditsCo());
	}

	IEnumerator OpenCreditsCo()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		creditsCanvas.SetActive(true);
		menuCanvas.SetActive(false);
	}

	public void OpenMainMenu()
	{
		Time.timeScale = 1;
		source.PlayOneShot(selectionSFX);
		StartCoroutine(OpenMainMenuCo());
	}

	IEnumerator OpenMainMenuCo()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		creditsCanvas.SetActive(false);
		menuCanvas.SetActive(true);
	}

	public void Resume()
	{
		Time.timeScale = 1;
		source.PlayOneShot(selectionSFX);
		StartCoroutine(ResumeCo()); 
	}

	IEnumerator ResumeCo()
	{
		yield return new WaitForSeconds(time);
		mainCanvas.SetActive(true);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(false);
		//Time.timeScale = 1;
	}

	public void Retry()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(RetryCo()); 
	}

	IEnumerator RetryCo()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}

	public void Level1()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level1Co()); 
	}

	IEnumerator Level1Co()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("Level1", LoadSceneMode.Single);
	}

	public void Level2()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level2Co()); 
	}

	IEnumerator Level2Co()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("Level2", LoadSceneMode.Single);
	}

	public void Level3()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level3Co()); 
	}

	IEnumerator Level3Co()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("Level3", LoadSceneMode.Single);
	}

	public void Level4()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level4Co()); 
	}

	IEnumerator Level4Co()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("Level4", LoadSceneMode.Single);
	}

	public void Level5()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level5Co()); 
	}

	IEnumerator Level5Co()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("Level5", LoadSceneMode.Single);
	}

	public void Level6()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level6Co()); 
	}

	IEnumerator Level6Co()
	{
		Time.timeScale = 1;
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene("Level6", LoadSceneMode.Single);
	}

	public void ExitApp()
	{
		Application.Quit();
	}
}
