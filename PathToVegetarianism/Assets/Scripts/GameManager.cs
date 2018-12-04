using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// VARIABLES

	public static bool gameOver = false;
	
	private GameOverSceneChange sceneChange;

	// EXECUTION FUNCTIONS

	private void Awake() {
		sceneChange = FindObjectOfType<GameOverSceneChange> ();
	}

	private void Update() {
		GameOver ();
		MainMenu ();
	}

	// METHODS

	private void GameOver()
	{
		// TODO: Handle game over
		if (gameOver)
			ChangeScene (sceneChange.scene);

		gameOver = false;

		if (SceneManager.GetActiveScene().name == "MainMenu")
			Player.levelCount = 0;
	}

	public void ExitGame() {
		Application.Quit ();
	}

	public void MainMenu()
	{
		if (Input.GetKey (KeyCode.Escape))
			ChangeScene ("MainMenu");
	}

	public static void ChangeScene (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	public void ChangeSceneButton (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
