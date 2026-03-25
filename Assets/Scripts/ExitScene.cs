using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScene : MonoBehaviour {

	public string level;
	private bool fade = false;
	public float speed = 0.8f;
	public float soundFadeSpeed = 0.5f;
	private float alpha = 0f;
	public Image img;
	public SoundManager sm;

	void OnTriggerEnter(Collider other){
		fade = true;
		NPCMessages.canMove = false;
		Invoke ("Load", 2.5f);
	}
	void Load(){
		SceneManager.LoadScene (level);
	}
	void Update(){
		if (fade && alpha < 1) {
			sm.music.volume -= soundFadeSpeed * Time.deltaTime;
			alpha += speed * Time.deltaTime;
			img.color = new Color (1, 1, 1, alpha);
		} else if(fade){
			Invoke ("SetBlack", 1f);
		}

	}
	void SetBlack(){
		img.color = new Color (0, 0, 0, 1);
	}

}
