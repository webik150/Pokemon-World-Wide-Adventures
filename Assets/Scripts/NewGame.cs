using UnityEngine;
using System.Collections;


public class NewGame : MonoBehaviour {
	//int saveNum;
	void OnClick() {
	//saveNum = PlayerPrefs.GetInt("saveNumber");
	Application.LoadLevel("Indoors");
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetString("TeleportDestination","NewGamePosition");
	}
}


