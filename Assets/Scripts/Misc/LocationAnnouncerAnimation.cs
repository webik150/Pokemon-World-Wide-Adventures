using UnityEngine;
using System.Collections;

public class LocationAnnouncerAnimation : MonoBehaviour {
	
	public UISprite sprite;
	// Use this for initialization
	void Start () {
		show ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void show(){
		for (float i = sprite.bottomAnchor.absolute; i <= sprite.height; i++) {
			sprite.bottomAnchor.absolute--;//-= 1 * Time.deltaTime;
			sprite.topAnchor.absolute--; //-= 1 * Time.deltaTime;
				}


	}
}
