using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Preview : MonoBehaviour {

	public Camera cam;
	public Camera playerCam;
	public Transform lookPosition;
	public Transform[] lookPositions;
	public Transform[] positions;
	public float[] lookPosSpeed;
	public float[] baseSpeed;
	public float endSpeed;
	public Text txt;
	public string place;
	public static List<string> placesDone = new List<string> ();

	private int i = 0;

	// Use this for initialization
	void Start () {
		if (placesDone.Contains (place)) {
			gameObject.GetComponent<FirstPersonController> ().enabled = true;
			playerCam.enabled = true;
			cam.enabled = false;
			txt.enabled = false;
			this.enabled = false;
		} else {
			playerCam.enabled = false;
			cam.enabled = true;
			txt.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
			Move ();
	}
	void Move(){
		Debug.Log ("Movimentacao atual: " + i.ToString ());
		if (cam.transform.position != positions [i].position || lookPosition.transform.position != lookPositions [i].position) {
			lookPosition.transform.position = Vector3.MoveTowards (lookPosition.transform.position, lookPositions [i].position, lookPosSpeed[i]);
			if (i != positions.Length - 1) {
				cam.transform.position = Vector3.MoveTowards (cam.transform.position, positions [i].position, baseSpeed[i]);
			} else {
				cam.transform.position = Vector3.MoveTowards (cam.transform.position, positions [i].position, endSpeed);
			}
			cam.transform.LookAt (lookPosition);
		} else if (i == positions.Length - 1) {
			gameObject.GetComponent<FirstPersonController> ().enabled = true;
			playerCam.enabled = true;
			cam.enabled = false;
			txt.enabled = false;
			placesDone.Add (place);
			this.enabled = false;
		} else {
			i++;
		}
	}
}
