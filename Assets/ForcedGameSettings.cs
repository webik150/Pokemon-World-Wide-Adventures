using UnityEngine;
using System.Collections;

public class ForcedGameSettings : MonoBehaviour {
	public int frameRateCap = 80;


	//Pre-init
	void Awake() {
		Application.targetFrameRate = frameRateCap;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
