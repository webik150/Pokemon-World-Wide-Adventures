using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public Transform obj;
	private bool ahoj = false;
	public Location scrpt;
	public GameObject locationAnnouncer;
	public Animation locationAnnouncerTween;
	public Material skybox;
	//private Skybox cameraSkybox;
	public Camera camera;
	void Start () {

	}
	
	void Update () {
		
	}


	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag("Location")){
			scrpt = other.gameObject.GetComponent<Location>();
			if (audio.clip != scrpt.music) {
				audio.Stop();
				audio.clip = scrpt.music;
				audio.Play();
			}



			if (locationAnnouncer != null) {
				locationAnnouncer.GetComponentInChildren<UILabel>().text = scrpt.name;
				locationAnnouncerTween.Play();
			}




			if (camera != null) {
				camera.GetComponent<Skybox>().material = scrpt.skybox;
			} else {
				//Camera.main.GetComponent<Skybox>().material = scrpt.skybox;
			}

		}
	}
	public void playScrpt(AudioClip clip){
		audio.Stop();
		audio.clip = clip;
		audio.Play();
	}


	//void OnTriggerLeave (Collider other){
	//	if (other.gameObject.CompareTag("Location")){
	//		audio.Stop();
	//	}
	//}
}
