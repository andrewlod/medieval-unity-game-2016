using UnityEngine;
using System.Collections;

public class TextureRepeat : MonoBehaviour {
	public float X = 8f;
	public float Y = 0.75f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<MeshRenderer> ().material.mainTextureScale = new Vector2 (X, Y);
	}
}
