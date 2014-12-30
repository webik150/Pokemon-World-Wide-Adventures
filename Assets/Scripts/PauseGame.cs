using UnityEngine;
using System;

[ExecuteInEditMode]
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("Pokemon/Menu/Pause")]

public class PauseGame : MonoBehaviour
{
	public int paused=0;
	public GameObject Pause;
	public GameObject HUD;
	public bool paus;
	void Update ()
	{
		if (NGUITools.GetActive(HUD)) {
			if (Input.GetKeyDown (KeyCode.Escape) && paused==0) {
				paus = true;
				paused = 1;
				
			} else {
				if (Input.GetKeyDown (KeyCode.Escape)&& paused==1) {
					paus = false;
					paused = 0;
					unPause();
				}
			}
			
			
			if (paus) {
				NGUITools.SetActive (Pause, true);
				AudioListener.pause = true;
				Time.timeScale=0;
			} 
				}

	}
	public void unPause(){
		NGUITools.SetActive (Pause, false);
		paused = 0;
		paus = false;
		AudioListener.pause = false;
		Time.timeScale=1;
	}
}