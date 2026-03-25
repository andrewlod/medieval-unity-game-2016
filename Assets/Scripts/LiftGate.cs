using UnityEngine;
using System.Collections;

public class LiftGate : MonoBehaviour {
	private bool isLift = false;
	public Transform target;
	public float speed = 5f;
	public BoxCollider col;
	public AudioClip clip;
	public SoundManager sm;
	bool played = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (sm.efx.clip == clip && !sm.efx.isPlaying) {
			played = false;
		}
		if (Info.dialogueLevel >= 2 && !isLift) {
			col.isTrigger = true;
			Invoke("Lift", 5);
		}
	}
	void Lift(){
		if (transform.position != target.position) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			if (!played) {
				sm.PlayEfx (clip, 2f);
				played = true;
			}
		} else {
			isLift = true;
		}

	}
}
