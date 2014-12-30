using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {
	public GameObject red;
	// Use this for initialization

	void Update(){
		if (!PlayerPrefs.HasKey("Player.Name")) {
			GetComponent<UIButton>().enabled = false;
				}
		else {
			GetComponent<UIButton>().enabled = true;
				}
	}
	void OnClick () {

	PlayerPrefs.SetInt("loaded"+PlayerPrefs.GetInt("saveNumber"), 1);
	Application.LoadLevel(PlayerPrefs.GetString("Player.Level"+PlayerPrefs.GetInt("saveNumber")));
		red = GameObject.Find("Red");
	Vector3 newPosition = Vector3.zero;
	newPosition.x = PlayerPrefs.GetFloat("x"+PlayerPrefs.GetInt("saveNumber"));
	newPosition.y = PlayerPrefs.GetFloat("y"+PlayerPrefs.GetInt("saveNumber"));
	newPosition.z = PlayerPrefs.GetFloat("z"+PlayerPrefs.GetInt("saveNumber"));
	transform.position = newPosition;
	Debug.Log("Game Loaded");
	
	}
	
	// Update is called once per frame

}
