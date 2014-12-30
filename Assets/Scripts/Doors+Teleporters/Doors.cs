using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {



	public float telRate = 2.0f;
	private float nextTel = 0.0f;
	public float telDistance = 10.0f;
	public Transform player;
	public string destination; // drag the destination object here
	public string destinationScene;
	public AudioClip teleportSound; // set this to the teleport sound, if any
	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	void OnMouseDown(){
		if(Time.time > nextTel && Vector3.Distance(player.position, transform.position) <= telDistance){
			nextTel = Time.time + telRate;
			PlayerPrefs.SetString("TeleportDestination",destination);
			//if (teleportSound){ // plays the sound effect at the destination
			//	AudioSource.PlayClipAtPoint(teleportSound, player.position);
			//}
			Application.LoadLevel(destinationScene);
		}
}
}
