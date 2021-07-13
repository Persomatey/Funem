using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Buttons : MonoBehaviour
{
	public GameObject mainCanvas;
	public GameObject pauseCanvas;
	public GameObject deathCanvas;
	public GameObject loadingCanvas; 
	private float waitTime;
	private AudioSource source;
	public AudioClip selectionSFX;
	public GameObject menuCanvas;
	public GameObject creditsCanvas;

	public bool readyToSwitch;
	private string sceneToSwitch;
	private AsyncOperation newScene;
	public Sprite progressBarFinishedSprite;

	private float fadeTime = 0.5f;
	private float minTimeInLoading = 0.5f; 

	private void Start()
	{
		gameObject.AddComponent<AudioSource>();
		source = GetComponent<AudioSource>(); 

		waitTime = selectionSFX.length;

		readyToSwitch = false;
	}

	private void Update()
	{
		if(readyToSwitch && Input.GetKeyDown("space"))
		{
			newScene.allowSceneActivation = true;
		}

		if(newScene != null && newScene.isDone)
		{
			var curScene = SceneManager.GetActiveScene();
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToSwitch));
			SceneManager.UnloadSceneAsync(curScene);
		}
	}

	public void ToMainMenu()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(ToMainMenuCo());
	}

	IEnumerator ToMainMenuCo()
	{
		Time.timeScale = 1;
		sceneToSwitch = "MainMenu";
		GameObject.Find("CrossfadeCanvas").GetComponent<Animator>().SetTrigger("Start");

		Destroy(GameObject.Find("PlayerArrow"));
		Destroy(GameObject.Find("PlayerWASD"));
		Destroy(GameObject.Find("PlayerController"));

		yield return new WaitForSeconds(fadeTime);
		loadingCanvas.SetActive(true);
		yield return new WaitForSeconds(minTimeInLoading);

		newScene = SceneManager.LoadSceneAsync(sceneToSwitch, LoadSceneMode.Additive);
		newScene.allowSceneActivation = false;
		RectTransform progressBar = GameObject.Find("ProgressBarFillImg").GetComponent<RectTransform>();

		do
		{
			progressBar.localScale = new Vector3(newScene.progress * 10, progressBar.localScale.y, progressBar.localScale.z);

		} while (newScene.progress < 0.9f);

		progressBar.localScale = new Vector3(10, progressBar.localScale.y, progressBar.localScale.z);
		progressBar.GetComponent<Image>().sprite = progressBarFinishedSprite;

		loadingCanvas.transform.Find("LoadingImg").gameObject.SetActive(false);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().text = "Press the Spacebar to continue";
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition.y);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		readyToSwitch = true;
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
		yield return new WaitForSeconds(waitTime);
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
		yield return new WaitForSeconds(waitTime);
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
		yield return new WaitForSeconds(waitTime);
		mainCanvas.SetActive(true);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(false);
		//Time.timeScale = 1;
	}

	public void Retry()
	{
		Time.timeScale = 1;
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(RetryCo()); 
	}

	IEnumerator RetryCo()
	{
		Time.timeScale = 1;
		sceneToSwitch = SceneManager.GetActiveScene().name;
		GameObject.Find("CrossfadeCanvas").GetComponent<Animator>().SetTrigger("Start");

		Destroy(GameObject.Find("PlayerArrow"));
		Destroy(GameObject.Find("PlayerWASD"));
		Destroy(GameObject.Find("PlayerController"));

		yield return new WaitForSeconds(fadeTime);
		loadingCanvas.SetActive(true);
		yield return new WaitForSeconds(minTimeInLoading);

		newScene = SceneManager.LoadSceneAsync(sceneToSwitch, LoadSceneMode.Additive);
		newScene.allowSceneActivation = false;
		RectTransform progressBar = GameObject.Find("ProgressBarFillImg").GetComponent<RectTransform>();

		do
		{
			progressBar.localScale = new Vector3(newScene.progress * 10, progressBar.localScale.y, progressBar.localScale.z);

		} while (newScene.progress < 0.9f);

		progressBar.localScale = new Vector3(10, progressBar.localScale.y, progressBar.localScale.z);
		progressBar.GetComponent<Image>().sprite = progressBarFinishedSprite;

		loadingCanvas.transform.Find("LoadingImg").gameObject.SetActive(false);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().text = "Press the Spacebar to continue";
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition.y);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		readyToSwitch = true;

	}

	public void Level1()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level1Co()); 
	}

	IEnumerator Level1Co()
	{
		Time.timeScale = 1;
		sceneToSwitch = "Level1";
		GameObject.Find("CrossfadeCanvas").GetComponent<Animator>().SetTrigger("Start");

		Destroy(GameObject.Find("PlayerArrow"));
		Destroy(GameObject.Find("PlayerWASD"));
		Destroy(GameObject.Find("PlayerController"));

		yield return new WaitForSeconds(fadeTime);
		loadingCanvas.SetActive(true);
		yield return new WaitForSeconds(minTimeInLoading);

		newScene = SceneManager.LoadSceneAsync(sceneToSwitch, LoadSceneMode.Additive);
		newScene.allowSceneActivation = false;
		RectTransform progressBar = GameObject.Find("ProgressBarFillImg").GetComponent<RectTransform>(); 

		do
		{
			progressBar.localScale = new Vector3(newScene.progress * 10, progressBar.localScale.y, progressBar.localScale.z); 
			
		} while (newScene.progress < 0.9f);

		progressBar.localScale = new Vector3(10, progressBar.localScale.y, progressBar.localScale.z);
		progressBar.GetComponent<Image>().sprite = progressBarFinishedSprite; 

		loadingCanvas.transform.Find("LoadingImg").gameObject.SetActive(false); 
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().text = "Press the Spacebar to continue";
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition.y);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().alignment = TextAnchor.MiddleCenter; 

		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		readyToSwitch = true;
	}

	public void Level2()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level2Co()); 
	}

	IEnumerator Level2Co()
	{
		Time.timeScale = 1;
		sceneToSwitch = "Level2";
		GameObject.Find("CrossfadeCanvas").GetComponent<Animator>().SetTrigger("Start");

		Destroy(GameObject.Find("PlayerArrow"));
		Destroy(GameObject.Find("PlayerWASD"));
		Destroy(GameObject.Find("PlayerController"));

		yield return new WaitForSeconds(fadeTime);
		loadingCanvas.SetActive(true);
		yield return new WaitForSeconds(minTimeInLoading);

		newScene = SceneManager.LoadSceneAsync(sceneToSwitch, LoadSceneMode.Additive);
		newScene.allowSceneActivation = false;
		RectTransform progressBar = GameObject.Find("ProgressBarFillImg").GetComponent<RectTransform>();

		do
		{
			progressBar.localScale = new Vector3(newScene.progress * 10, progressBar.localScale.y, progressBar.localScale.z);

		} while (newScene.progress < 0.9f);

		progressBar.localScale = new Vector3(10, progressBar.localScale.y, progressBar.localScale.z);
		progressBar.GetComponent<Image>().sprite = progressBarFinishedSprite;

		loadingCanvas.transform.Find("LoadingImg").gameObject.SetActive(false);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().text = "Press the Spacebar to continue";
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition.y);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		readyToSwitch = true;
	}

	public void Level3()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level3Co()); 
	}

	IEnumerator Level3Co()
	{
		Time.timeScale = 1;
		sceneToSwitch = "Level3";
		GameObject.Find("CrossfadeCanvas").GetComponent<Animator>().SetTrigger("Start");

		Destroy(GameObject.Find("PlayerArrow"));
		Destroy(GameObject.Find("PlayerWASD"));
		Destroy(GameObject.Find("PlayerController"));

		yield return new WaitForSeconds(fadeTime);
		loadingCanvas.SetActive(true);
		yield return new WaitForSeconds(minTimeInLoading);

		newScene = SceneManager.LoadSceneAsync(sceneToSwitch, LoadSceneMode.Additive);
		newScene.allowSceneActivation = false;
		RectTransform progressBar = GameObject.Find("ProgressBarFillImg").GetComponent<RectTransform>();

		do
		{
			progressBar.localScale = new Vector3(newScene.progress * 10, progressBar.localScale.y, progressBar.localScale.z);

		} while (newScene.progress < 0.9f);

		progressBar.localScale = new Vector3(10, progressBar.localScale.y, progressBar.localScale.z);
		progressBar.GetComponent<Image>().sprite = progressBarFinishedSprite;

		loadingCanvas.transform.Find("LoadingImg").gameObject.SetActive(false);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().text = "Press the Spacebar to continue";
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition.y);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		readyToSwitch = true;
	}

	public void Level4()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level4Co()); 
	}

	IEnumerator Level4Co()
	{
		Time.timeScale = 1;
		sceneToSwitch = "Level4";
		GameObject.Find("CrossfadeCanvas").GetComponent<Animator>().SetTrigger("Start");

		Destroy(GameObject.Find("PlayerArrow"));
		Destroy(GameObject.Find("PlayerWASD"));
		Destroy(GameObject.Find("PlayerController"));

		yield return new WaitForSeconds(fadeTime);
		loadingCanvas.SetActive(true);
		yield return new WaitForSeconds(minTimeInLoading);

		newScene = SceneManager.LoadSceneAsync(sceneToSwitch, LoadSceneMode.Additive);
		newScene.allowSceneActivation = false;
		RectTransform progressBar = GameObject.Find("ProgressBarFillImg").GetComponent<RectTransform>();

		do
		{
			progressBar.localScale = new Vector3(newScene.progress * 10, progressBar.localScale.y, progressBar.localScale.z);

		} while (newScene.progress < 0.9f);

		progressBar.localScale = new Vector3(10, progressBar.localScale.y, progressBar.localScale.z);
		progressBar.GetComponent<Image>().sprite = progressBarFinishedSprite;

		loadingCanvas.transform.Find("LoadingImg").gameObject.SetActive(false);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().text = "Press the Spacebar to continue";
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition.y);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		readyToSwitch = true;
	}

	public void Level5()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level5Co()); 
	}

	IEnumerator Level5Co()
	{
		Time.timeScale = 1;
		sceneToSwitch = "Level5";
		GameObject.Find("CrossfadeCanvas").GetComponent<Animator>().SetTrigger("Start");

		Destroy(GameObject.Find("PlayerArrow"));
		Destroy(GameObject.Find("PlayerWASD"));
		Destroy(GameObject.Find("PlayerController"));

		yield return new WaitForSeconds(fadeTime);
		loadingCanvas.SetActive(true);
		yield return new WaitForSeconds(minTimeInLoading);

		newScene = SceneManager.LoadSceneAsync(sceneToSwitch, LoadSceneMode.Additive);
		newScene.allowSceneActivation = false;
		RectTransform progressBar = GameObject.Find("ProgressBarFillImg").GetComponent<RectTransform>();

		do
		{
			progressBar.localScale = new Vector3(newScene.progress * 10, progressBar.localScale.y, progressBar.localScale.z);

		} while (newScene.progress < 0.9f);

		progressBar.localScale = new Vector3(10, progressBar.localScale.y, progressBar.localScale.z);
		progressBar.GetComponent<Image>().sprite = progressBarFinishedSprite;

		loadingCanvas.transform.Find("LoadingImg").gameObject.SetActive(false);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().text = "Press the Spacebar to continue";
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition.y);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		readyToSwitch = true;
	}

	public void Level6()
	{
		source.PlayOneShot(selectionSFX); 
		StartCoroutine(Level6Co()); 
	}

	IEnumerator Level6Co()
	{
		Time.timeScale = 1;
		sceneToSwitch = "Level6";
		GameObject.Find("CrossfadeCanvas").GetComponent<Animator>().SetTrigger("Start");

		Destroy(GameObject.Find("PlayerArrow"));
		Destroy(GameObject.Find("PlayerWASD"));
		Destroy(GameObject.Find("PlayerController"));

		yield return new WaitForSeconds(fadeTime);
		loadingCanvas.SetActive(true);
		yield return new WaitForSeconds(minTimeInLoading);

		newScene = SceneManager.LoadSceneAsync(sceneToSwitch, LoadSceneMode.Additive);
		newScene.allowSceneActivation = false;
		RectTransform progressBar = GameObject.Find("ProgressBarFillImg").GetComponent<RectTransform>();

		do
		{
			progressBar.localScale = new Vector3(newScene.progress * 10, progressBar.localScale.y, progressBar.localScale.z);

		} while (newScene.progress < 0.9f);

		progressBar.localScale = new Vector3(10, progressBar.localScale.y, progressBar.localScale.z);
		progressBar.GetComponent<Image>().sprite = progressBarFinishedSprite;

		loadingCanvas.transform.Find("LoadingImg").gameObject.SetActive(false);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().text = "Press the Spacebar to continue";
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
		loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, loadingCanvas.transform.Find("LoadingText").GetComponent<RectTransform>().anchoredPosition.y);
		loadingCanvas.transform.Find("LoadingText").GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		readyToSwitch = true;
	}

	public void ExitApp()
	{
		Application.Quit();
	}
}
