using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour {
	private static int  score;
	private AudioSource audio;
	private playerMovement playerMovementScript;

	void Start(){
		audio = GetComponent<AudioSource> ();
		GameObject playerGameObject = GameObject.FindWithTag ("Player");
		if (playerGameObject != null) {
			playerMovementScript = playerGameObject.GetComponent<playerMovement> ();
		}
		if (playerGameObject == null) {
			Debug.Log ("Cannot find Player script");
		}
	}


	void OnTriggerExit2D(Collider2D other){
		
		if (other.tag == "Player") {
			playerMovementScript.UpdateScore ();
			audio.Play ();
		}
	}
}
