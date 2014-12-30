using UnityEngine;
using System.Collections;

public class SaveGame : MonoBehaviour {
	// Use this for initialization
	public Transform pl;
	public int saveNumber;

	void Start(){
		pl = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void OnClick () {
		PlayerPrefs.SetInt("saveNumber", saveNumber);
		pl.GetComponent<Party>().savePokemon(saveNumber);
		PlayerPrefs.SetString("Player.Name",pl.GetComponent<PlayerInfo>().name);
		PlayerPrefs.SetFloat("x"+saveNumber, pl.position.x);
		PlayerPrefs.SetFloat("y"+saveNumber, pl.position.y);
		PlayerPrefs.SetFloat("z"+saveNumber, pl.position.z);
		PlayerPrefs.SetString("Player.Level"+saveNumber, Application.loadedLevelName);
		PlayerPrefs.SetInt("loaded"+saveNumber, 1);
		Debug.Log("Saved Game "+saveNumber);
		Debug.Log(Application.loadedLevelName);
	}
}