using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainCollision : MonoBehaviour {

	private playerMovement playerMovementScript;
	private AudioSource audio;

	void Start() {
		GameObject playerGameObject = GameObject.FindWithTag ("Player");
		if (playerGameObject != null) {
			playerMovementScript = playerGameObject.GetComponent<playerMovement> ();
		}
		if (playerGameObject == null) {
			Debug.Log ("Cannot find Player script");
		}

		audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Player Destroyed boss");
			audio.Play ();
			playerMovementScript.ResetPlayer ();

		}
	}
}
