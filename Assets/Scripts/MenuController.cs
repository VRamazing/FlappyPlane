using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MenuController : MonoBehaviour {
	public Transform player;
	private string gameObjectName;
	GameObject redPlane;
	GameObject greenPlane;

//	public void OnPointerUp (PointerEventData eventData)
//	{
//		gameObjectName =  eventData.pointerCurrentRaycast.gameObject.name;
//		Debug.Log (gameObjectName);
//		if (gameObjectName == "Text") {
//			SwitchPlane ();
//		} else {
//			Debug.Log ("Start game");
//		}
//	}

	void Start(){
		redPlane = player.Find("planeRed").gameObject;
		greenPlane = player.Find("planeGreen").gameObject;
		int planePref = PlayerPrefs.GetInt ("Plane", 0);
		if (planePref == 0) {
			redPlane.SetActive (false);
			greenPlane.SetActive (true);
		} else {
			redPlane.SetActive (true);
			greenPlane.SetActive (false);
		}
	}
		
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			// Check if finger is over a UI element
			if (!EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)) {
				
				SceneManager.LoadScene ("Main");
			}
		} else {
			if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject ()){
				
				SceneManager.LoadScene ("Main");
			}
		
		}


	}

	public void SwitchPlane(){
		if (Input.touchCount > 0 ) {
			
			if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)) {

				if (redPlane.activeInHierarchy) {

					redPlane.SetActive (false);
					greenPlane.SetActive (true);
					PlayerPrefs.SetInt ("Plane", 0);
				} else if (greenPlane.activeInHierarchy) {

					redPlane.SetActive (true);
					greenPlane.SetActive (false);
					PlayerPrefs.SetInt ("Plane", 1);
				}

			}

		} else {
			if (EventSystem.current.IsPointerOverGameObject ()) {

				if (redPlane.activeInHierarchy) {

					redPlane.SetActive (false);
					greenPlane.SetActive (true);
					PlayerPrefs.SetInt ("Plane", 0);
				}

				else if (greenPlane.activeInHierarchy) {

					redPlane.SetActive (true);
					greenPlane.SetActive (false);
					PlayerPrefs.SetInt ("Plane", 1);
				}

			}
		
		}

	

	
	}
}
