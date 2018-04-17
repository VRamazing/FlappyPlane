using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour {

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

	void OnTriggerExit2D(Collider2D other){
		Debug.Log("working till here");
		if (other.tag == "Player") {
			Debug.Log ("Player Destroyed boss");
			audio.Play ();
			playerMovementScript.ResetPlayer ();
		} 
		else {
			Destroy (other.transform.parent.gameObject);
		}


	}
}
