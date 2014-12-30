using UnityEngine;
using System.Collections;

public class ResumeGame : MonoBehaviour {

	// Use this for initialization

		void OnClick(){
        GameObject thePlayer = GameObject.Find("Red");
        PauseGame pauseGame = thePlayer.GetComponent<PauseGame>();
		pauseGame.paused = 0;
		pauseGame.paus = false;
		pauseGame.unPause();
		}

	
	// Update is called once per frame

}
