using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSpawner : MonoBehaviour {

	// VARIABLES

	public GameObject[] meatPieces;
	public GameObject[] textToSpawn;

	public bool force;
	public Vector2 forceValue;

	private bool spawned = false;

	// EXECUTION FUNCTIONS

	private void Awake()
	{
		Disabler ();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.GetComponent<Player> () == null)
			return;

		if (force)
			ForceSpawn ();
		else
			Spawn ();
	}

	// METHODS

	private void Spawn()
	{
		if (spawned)
			return;
		
		foreach (GameObject meat in meatPieces)
			meat.SetActive (true);

		foreach (GameObject text in textToSpawn)
			text.SetActive (true);
	
		spawned = true;
	}

	private void ForceSpawn()
	{
		if (spawned)
			return;

		foreach (GameObject meat in meatPieces) {
			meat.SetActive (true);
			meat.GetComponent<Rigidbody2D> ().AddForce (forceValue);	
		}

		foreach (GameObject text in textToSpawn)
			text.SetActive (true);
	
		spawned = true;
	}

	private void Disabler()
	{
		foreach (GameObject meat in meatPieces)
			meat.SetActive (false);

		foreach (GameObject text in textToSpawn)
			text.SetActive (false);
	}
}
