using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
[RequireComponent(typeof(UIPanel))]
public class PauseGameOnUpdate : MonoBehaviour {


	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void OnEnable () {
		//Debug.Log(5);
			Time.timeScale=0;


	}
	void OnDisable(){
		//Debug.Log(8);
		Time.timeScale=1;
	}
}
