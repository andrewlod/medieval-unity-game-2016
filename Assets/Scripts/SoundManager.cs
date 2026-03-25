using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource efx;
	public AudioSource music;

	public void PlayMusic(AudioClip clip, float volume){
		music.volume = volume;
		music.clip = clip;
		music.Play ();
	}
	public void PlayEfx(AudioClip clip, float volume){
		efx.volume = volume;
		efx.clip = clip;
		efx.Play ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
