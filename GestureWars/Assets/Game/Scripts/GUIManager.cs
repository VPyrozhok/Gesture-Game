using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public GameObject StartMenu;
	public GameObject GameOverMenu;
	public GameObject Playgrounds;
	public delegate void CallBack();
	public static event CallBack OnGameBegin_event;

	void Awake() {
		PlaygroundAction.GameOver_event += EndGame;  //// TO DO: Enable disable 
	}

	public void StartGame() {
		StartMenu.SetActive(false);
		Playgrounds.SetActive(true);
		OnGameBegin_event();


	}

	public void RestartGame() {
		PlaygroundAction.GameOver_event -= EndGame;
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void EndGame() {
		GameOverMenu.SetActive(true);
		Playgrounds.SetActive(false);

	}


}
