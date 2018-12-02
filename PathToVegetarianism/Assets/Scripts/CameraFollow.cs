using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// VARIABLES

	private Player player;
	public Vector3 offset;

	// EXECUTION FUNCTION

	private void Awake()
	{
		player = FindObjectOfType<Player> ();
	}

	private void Update()
	{
		FollowPlayer ();
	}

	// METHODS

	private void FollowPlayer()
	{
		this.transform.position = player.transform.position + offset;
	}
}
