using UnityEngine;
using System.Collections;

public class PokeMessageScript : MonoBehaviour {

	public GameObject thismessagebox;
	public UILabel label;

	public string[] messages;
	public int messageCount = 1;
	public int currentMessage = 1;
	int b = 0;

	void Update () {
	if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space)) {
			messageProcessing();
				}
		if (b > 5) {
			b = 0;
		}
		else {
			if (b!= 5) {
				b++;
			}

		}
	}
	void OnEnable(){

	}



	void OnClick () {
		//Debug.Log("Pressed");
		messageProcessing();

	}


	void messageProcessing(){
		if (b == 5) {
			if (messages == null || currentMessage == messageCount) {
				label.text = "";

				NGUITools.SetActive(thismessagebox,false);
			}
			else {
				
				label.text = messages[currentMessage];
				currentMessage++;
			}
			b++;
			
		}
	}
}
