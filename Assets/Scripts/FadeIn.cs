using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	private float speed = -0.8f;
	private float alpha = 1f;
	public Image img;

	void Start(){
		NPCMessages.canMove = true;
	}
	void Update(){
		if (alpha > 0) {
			alpha += speed * Time.deltaTime;
			img.color = new Color (0, 0, 0, alpha);
		}

	}
}
