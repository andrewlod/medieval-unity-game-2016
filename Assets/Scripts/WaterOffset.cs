using UnityEngine;
using System.Collections;

public class WaterOffset : MonoBehaviour {

	public float speedX = 0.1f;
	public float speedY = 0.1f;
	public bool isRandom = false;
	public float randomCooldown = 0f;
	private float curX;
	private float curY;
	private float nextX;
	private float nextY;
	private float currentTime = 0f;
	public Material m;


	// Use this for initialization
	void Awake () {
		curX = m.mainTextureOffset.x;
		curY = m.mainTextureOffset.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isRandom) {
			curX += Time.deltaTime *speedX;
			curY += Time.deltaTime *speedY;
		} else {
			SetRandomXY ();
			curX += (Time.time - currentTime) * nextX * speedX;
			curY += (Time.time - currentTime) * nextY * speedY;
		}
		m.SetTextureOffset ("_MainTex", new Vector2(curX, curY));
	}
	void SetRandomXY(){
		if (Time.time - currentTime >= randomCooldown) {
			nextX = Random.Range (-speedX, speedX);
			nextY = Random.Range (-speedY, speedY);
			currentTime = Time.time;
		}
	}
}
