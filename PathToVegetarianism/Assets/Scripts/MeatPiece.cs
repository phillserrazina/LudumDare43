using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPiece : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.GetComponent<Player> () == null)
			return;

		GameManager.gameOver = true;
	}
}
