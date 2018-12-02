using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour {

	public string nextScene;

	private void OnTriggerEnter2D (Collider2D col) 
	{
		if (col.gameObject.GetComponent<Player> () == null)
			return;
	
		GameManager.ChangeScene (nextScene);

		if (SceneManager.GetActiveScene().name != "Level_00" &&
			SceneManager.GetActiveScene().name != "Level_00_b" &&
			SceneManager.GetActiveScene().name != "Level_00_c" &&
			SceneManager.GetActiveScene().name != "Tutorial")
			Player.levelCount++;
	}
}
