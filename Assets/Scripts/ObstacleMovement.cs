using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

	public float speed = 5;

	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D> ().velocity = transform.right * speed;
		
	}
}
