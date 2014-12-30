using UnityEngine;
using System.Collections;

public class ShowHidePokemonHUD : MonoBehaviour {

	public UISprite[] pokemon = new UISprite[6];
	public UISprite[] expBars = new UISprite[6];

	private bool hidden = false;

	// Use this for initialization
	void Start () {
	for (int i = 0; i < 6; i++) {
			expBars[i] = pokemon[i].transform.FindChild("EXPBar").GetComponent<UISprite>();
				}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("hidepokemon") && !hidden) {

			for (int i = 0; i < 6; i++) {
				pokemon[i].leftAnchor.absolute = -176;
				pokemon[i].rightAnchor.absolute = 90;
				NGUITools.SetActive(expBars[i].gameObject,false);
			}
			//Debug.Log(hidden+" a schovavam");
			hidden = true;
			return;

		}
		if (Input.GetButtonDown("hidepokemon") && hidden) {
			
			for (int i = 0; i < 6; i++) {
				pokemon[i].leftAnchor.absolute = 0;
				pokemon[i].rightAnchor.absolute = 256;
				NGUITools.SetActive(expBars[i].gameObject,true);
			}
			//Debug.Log(hidden+" a otviram");
			hidden = false;
			return;
		}


	}
}
