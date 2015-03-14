using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Data data;
	public Text information;
	public Text playButtonText;
	public Text quitButtonText;
	public Text titleText;	
	public Button playButton;
	public Button quitButton;

	// Use this for initialization
	void Start () {
		data = GameObject.Find("Data").GetComponent<Data>();
		setMenu();
	}
	void setMenu() {
		switch(data.GameState) {
		case GameStates.MainMenu:
			MainMenu();
			break;
		case GameStates.Paused:
			PauseMenu();
			break;
		case GameStates.Running:
			break;
		case GameStates.GameOverLoss:
			GameOverMenu();
			break;
		case GameStates.GameOverWin:
			WinMenu();
			break;
		}
	}

	void PrintTitle(string text = "") {
		titleText.text = Data.title;
		information.text = text + Data.information;
		
	}
	void MainMenu() {
		playButtonText.text = "Start";
		PrintTitle();
		
	}
	void GameOverMenu() {
		playButtonText.text = "Retry";
		PrintTitle("Game Over\n");
	}
	void WinMenu() {
		playButtonText.text = "Restart";
		PrintTitle("Congratulations You Survived\n");
	}
	void PauseMenu() {
		playButtonText.text = "Continue";
		PrintTitle("PAUSED\n");
	}
	public void Quit() {
		Debug.Log("Quiting Game");
		Application.Quit();
	}
	public void StartGame() {
		Debug.Log("starting Game");
		hideMenu();
		data.SetGameState(GameStates.Running);
	}
	void hideMenu() {
		Debug.Log("Destroying");
		Destroy(this.gameObject);
	}
}
