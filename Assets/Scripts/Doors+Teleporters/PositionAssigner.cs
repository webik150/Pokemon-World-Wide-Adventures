using UnityEngine;
using System.Collections;

public class PositionAssigner : MonoBehaviour {

	public AudioClip sound;
	public Transform player;
	public GameObject destination;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;

		if(PlayerPrefs.HasKey("TeleportDestination")){
		destination = GameObject.Find(PlayerPrefs.GetString("TeleportDestination"));
		}
		if (destination) {
			player.position = destination.transform.position;
			player.rotation = destination.transform.rotation;
				}

		if (sound){ // plays the sound effect at the destination
			AudioSource.PlayClipAtPoint(sound, player.position);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
