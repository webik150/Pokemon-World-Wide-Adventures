using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TextOnClick : MonoBehaviour {


	public string text;
	public GameObject messageBox;
	public int displayDistance = 10;
	public UILabel label;

	private float telRate = 1;
	private float nextTel; 
	GameObject thePlayer;
	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find("Red");
	}
	

	void OnMouseDown () {
		if (!messageBox.activeInHierarchy && Time.time > nextTel && Vector3.Distance(this.transform.position, thePlayer.transform.position) <= displayDistance && !thePlayer.GetComponent<PauseGame>().paus){

		nextTel = Time.time + telRate;
		NGUITools.SetActive(messageBox,true);
		label.text = text;
		//Debug.Log("Hello");

		}
	}
}
