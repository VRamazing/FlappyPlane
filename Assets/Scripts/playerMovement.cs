using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class playerMovement : MonoBehaviour {
	private Rigidbody2D playerRigidBody;
	public int speed;
	public float tiltSmooth;
	public Vector2  startPos;
	public Text scoreText, bestText;
	private int  score = 0;

	Quaternion downRotation, upRotation;


	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		downRotation = Quaternion.Euler (0, 0, -90);
		upRotation = Quaternion.Euler (0, 0, 35);
		scoreText.text = "Score : " + score;
		bestText.text = "Best  : " + PlayerPrefs.GetInt ("BestScore", 0);
		GameObject planeRed = gameObject.transform.Find ("planeRed").gameObject;
		GameObject planeGreen = gameObject.transform.Find ("planeGreen").gameObject;
		if (PlayerPrefs.GetInt ("Plane") == 1) {
			Debug.Log("done 1");
			planeRed.SetActive (true);
			planeGreen.SetActive (false);
		} else  if (PlayerPrefs.GetInt ("Plane") == 0){
			Debug.Log("done 0");
			planeRed.SetActive (false);
			planeGreen.SetActive (true);
		}
	}
		
	public void ResetPlayer(){
		downRotation = Quaternion.Euler (0, 0, -90);
		upRotation = Quaternion.Euler (0, 0, 35);
		playerRigidBody.velocity = new Vector2(0,0);
		transform.position = startPos;
		transform.rotation = Quaternion.Euler (0, 0, 0);
		if (score > PlayerPrefs.GetInt ("BestScore", 0)) {
			PlayerPrefs.SetInt ("BestScore", score);
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void UpdateScore(){
		score++;
		scoreText.text = "Score : " + score;
	}

	public void LoadMenu(){
		SceneManager.LoadScene ("Menu");
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject ()) {
			playerRigidBody.velocity = new Vector2 (0.0f, speed);
			transform.rotation = upRotation;
		}

		transform.rotation = Quaternion.Lerp (transform.rotation, downRotation, tiltSmooth * Time.deltaTime);

	}
}
