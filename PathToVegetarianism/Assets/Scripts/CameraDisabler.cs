using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisabler : MonoBehaviour {

	private CameraFollow cam;

	private void Awake()
	{
		cam = FindObjectOfType<CameraFollow> ();
	}

	private void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.GetComponent<Player> () == null)
			return;

		cam.enabled = false;
	}

	private void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.GetComponent<Player> () == null)
			return;

		cam.enabled = true;
	}
}
