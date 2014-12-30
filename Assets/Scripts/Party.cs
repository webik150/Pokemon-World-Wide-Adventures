using UnityEngine;
using System.Collections;

public class Party : MonoBehaviour {

	public Pokemon[] party = new Pokemon[6];
	public InitPokemon pokeDB;
	// Use this for initialization
	void Start () {
		loadPokemon(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void savePokemon(int savenumber){
		for (int i = 0; i < party.Length; i++) {
			Debug.Log(party[i]);
			if (party[i] != null) {
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".ID", party[i].ID);
			PlayerPrefs.SetString("Player."+savenumber+".Pokemon.Party."+i+".Nickname", party[i].nickname);
			PlayerPrefs.SetString("Player."+savenumber+".Pokemon.Party."+i+".Nature", party[i].nature.name);
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".IVAttack", party[i].IVAttack);
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".IVSpAttack", party[i].IVSpAttack);
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".IVDefense", party[i].IVDefense);
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".IVSpDefense", party[i].IVSpDefense);
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".IVSpeed", party[i].IVSpeed);
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".IVHP", party[i].IVHP);
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".CurrentHP", party[i].currentHP);
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".CurrentEXP", party[i].currentExp);
			PlayerPrefs.SetInt("Player."+savenumber+".Pokemon.Party."+i+".Level",party[i].level);
			}
		}
	}
	public void loadPokemon(int savenumber){


		for (int i = 0; i < party.Length; i++) {
			if(PlayerPrefs.HasKey("Player."+savenumber+".Pokemon.Party."+i+".ID")){
				//party[i] = (Pokemon)gameObject.AddComponent("Pokemon");
				Pokemon tempPoke = pokeDB.pokemonArray[PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".ID")-1];
				tempPoke.transform.position = Vector3.zero;
				party[i] = (Pokemon)Instantiate(tempPoke);
				party[i].ID = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".ID");
				party[i].nickname = PlayerPrefs.GetString("Player."+savenumber+".Pokemon.Party."+i+".Nickname");
				party[i].nature = GameObject.Find(PlayerPrefs.GetString("Player."+savenumber+".Pokemon.Party."+i+".Nature")).GetComponent<Nature>();
				party[i].IVAttack = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".IVAttack");
				party[i].IVSpAttack = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".IVSpAttack");
				party[i].IVDefense = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".IVDefense");
				party[i].IVSpDefense = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".IVSpDefense");
				party[i].IVSpeed = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".IVSpeed");
				party[i].IVHP = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".IVHP");
				party[i].currentHP = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".CurrentHP");
				party[i].currentExp = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".CurrentEXP");
				party[i].level = PlayerPrefs.GetInt("Player."+savenumber+".Pokemon.Party."+i+".Level");
				party[i].HP = party[i].calculateHP();
				party[i].Attack = party[i].calculateAttack();
				party[i].SpAttack = party[i].calculateSpAttack();
				party[i].SpDefense = party[i].calculateSpDefense();
				party[i].Defense = party[i].calculateDefense();
				party[i].Speed = party[i].calculateSpeed();
				}
		}
	}
	public void givePokemon (Pokemon pokemon){
		for (int i = 0; i < party.Length; i++) {
			if (party[i] == null) {
				party[i] = (Pokemon)Instantiate(pokemon);
				Debug.Log(pokemon.name);
				return;

			}
				}
	}
}
