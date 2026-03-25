using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCMessages : MonoBehaviour {

	public KeyCode next;
	public KeyCode interact;
	public GameObject player;
	public string[] chat;
	public bool hasInteract = false;
	public Text phrase;
	public Text x;
	public Text interactTxt;
	public Image E;
	public Image textBox;
	public int neededDLevel;
	public AudioClip nextMsg;
	public AudioClip startMsg;
	public SoundManager sm;

	private float musicVolume;

	public static bool canMove = true;
	private bool canInteract = false;

	void Start(){
		musicVolume = sm.music.volume;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			canInteract = true;
		}
	}
	void OnTriggerStay(Collider other){
		if(other.gameObject.CompareTag("Player")){
			if (hasInteract && canInteract) {
				E.enabled = true;
				interactTxt.enabled = true;
				if (Input.GetKey (interact)) {
					sm.PlayEfx (startMsg, 1f);
					sm.music.volume *= 0.5f;
					StartCoroutine(Dialogue ());
					E.enabled = false;
					interactTxt.enabled = false;
					canInteract = false;
				}
			}
			else if (neededDLevel == Info.dialogueLevel && !hasInteract) {
					sm.PlayEfx (startMsg, 1f);
					sm.music.volume *= 0.5f;
					StartCoroutine(Dialogue ());
					Info.dialogueLevel++;
			}
		}
	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("Player") && hasInteract){
			E.enabled = false;
			interactTxt.enabled = false;
		}
	}

	IEnumerator Dialogue(){
		canMove = false;
		x.enabled = true;
		textBox.enabled = true;
		phrase.enabled = true;
		for (int i = 0; i < chat.Length; i++) {
			phrase.text = chat [i];
			Debug.Log (chat [i]);
			yield return StartCoroutine(Say (i));
		}
		canMove = true;
		textBox.enabled = false;
		phrase.enabled = false;
		x.enabled = false;
		sm.music.volume = musicVolume;
	}

	IEnumerator Say(int i){
		while(!Input.GetKey (next)) {
			yield return null;
		} 
		if(Input.GetKey(next)){
			sm.PlayEfx (nextMsg, 1f);
		}
		yield return new WaitForSeconds (0.5f);
	}
}
