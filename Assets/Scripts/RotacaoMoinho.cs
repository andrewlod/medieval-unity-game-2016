using UnityEngine;
using System.Collections;

public class RotacaoMoinho : MonoBehaviour {

	public float vel = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (new Vector3 (vel, 0, 0));
	
	}
}
