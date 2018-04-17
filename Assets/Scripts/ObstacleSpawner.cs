using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public float ObstacleHeightRange = 2.81f;
	public GameObject Obstacle;
	public float ObstacleWaitTime = 1.01f;
	public Vector2 position; 

	// Use this for initialization
	void Start () {
		StartCoroutine (spawnObstacle ());
		position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
	}

	IEnumerator spawnObstacle(){
		
		while (true) {
			yield return new WaitForSeconds (ObstacleWaitTime);
			Vector2 spawnPosition = new Vector2 (position [0], position [1] + Random.Range (-ObstacleHeightRange, ObstacleHeightRange));
			Quaternion spawnRotation = Quaternion.identity; //No rotation
			Instantiate (Obstacle, spawnPosition, spawnRotation);
		}

//			if (gameOver) {
//				restartText.text= "Press R for Restart";
//				restart = true;
//				break;
//			}
//		}
	}
}
