using UnityEngine;
using System.Collections;

public class ColorChangeOnHover : MonoBehaviour {

	// Use this for initialization

	Color32 initCol;
	public int materialID;
	public byte RED = 72;
	public byte GREEN = 125;
	public byte BLUE = 168;
	Color32 changeto;
	public GameObject target;
	GameObject red;

	void Start(){
		red = GameObject.Find("Red");
		initCol = target.renderer.materials[materialID].color;
		changeto = new Color32(RED,GREEN,BLUE,255);

	}

	void OnMouseOver () {
		if (red.GetComponent<PauseGame>().paus) {
			return;
				}
		target.renderer.materials[materialID].color = changeto;

	}
	void OnMouseExit(){
		if (red.GetComponent<PauseGame>().paus) {
			return;
		}
		target.renderer.materials[materialID].color = initCol;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
