using UnityEngine;
using System.Collections;

public class GivePokemon : Pokemon {

	Pokemon pokemon;
	Pokemon pokemonInfo;
	GameObject thePlayer;

	// Use this for initialization
	void Start () {
		//pokemon = (Pokemon)gameObject.AddComponent("Pokemon");
		thePlayer = GameObject.Find("Red");
		//pokemonInfo = (Pokemon)Instantiate(GameObject.Find("PokeDB").GetComponent<InitPokemon>().pokemonArray[ID-1]);
		pokemon = (Pokemon)Instantiate(GameObject.Find("PokeDB").GetComponent<InitPokemon>().pokemonArray[ID-1]);
//		pokemon.type = pokemonInfo.type;
//		pokemon.type2 = pokemonInfo.type2;
//		pokemon.name = pokemonInfo.name;
//		pokemon.BaseHP = pokemonInfo.BaseHP;
//		pokemon.BaseAttack = pokemonInfo.BaseAttack;
//		pokemon.BaseSpAttack = pokemonInfo.BaseSpAttack;
//		pokemon.BaseDefense = pokemonInfo.BaseDefense;
//		pokemon.BaseSpDefense = pokemonInfo.BaseSpDefense;
//		pokemon.BaseSpeed = pokemonInfo.BaseSpeed;
		if (expType == "") {
			//pokemon.expType = pokemonInfo.expType;
			expType = pokemon.expType;
				}
		else {
			pokemon.expType = expType;
				}
		pokemon.ID = ID;
		pokemon.nature = nature;
		pokemon.level = level;
		pokemon.IVHP = IVHP;
		pokemon.IVAttack = IVAttack;
		pokemon.IVDefense = IVDefense;
		pokemon.IVSpAttack = IVSpAttack;
		pokemon.IVSpDefense = IVSpDefense;
		pokemon.IVSpeed = IVSpeed;
		pokemon.Speed = calculateSpeed();
		pokemon.Attack = calculateAttack();
		pokemon.SpAttack = calculateSpAttack();
		pokemon.Defense = calculateDefense();
		pokemon.SpDefense = calculateSpDefense();
		pokemon.currentExp = currentExp;
		pokemon.HP = calculateHP();
		pokemon.currentHP = pokemon.HP;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){

		if (Vector3.Distance(this.transform.position, thePlayer.transform.position) <= 10 && !thePlayer.GetComponent<PauseGame>().paus){
			pokemon.Heal();
			thePlayer.GetComponent<Party>().givePokemon(pokemon);
			DestroyImmediate(pokemonInfo);
			DestroyImmediate(pokemon);
		}

	}
}
