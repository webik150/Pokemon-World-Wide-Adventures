using UnityEngine;
using System.Collections;

public class StopOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<TweenPosition>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
