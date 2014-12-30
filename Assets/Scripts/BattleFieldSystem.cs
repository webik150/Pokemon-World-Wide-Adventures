using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleFieldSystem : MonoBehaviour
{


		public GameObject messageBox;
		public PokeMessageScript messageBoxBackground;
		public UILabel messageBoxLabel;
		public bool inBattle = false;
		public AudioClip normalBattleMusic;
		
		int roundCounter = 0;
		BattleHPBar healthBarFriend;
		BattleHPBar healthBarFoe;
		int activePokemon;
		Pokemon activePokemonPokemon;
		Pokemon foePokemon;
		GameObject battleUIPanel;
		GameObject HUDPanel;
		Camera maincCamera;
		Camera battleCamera;
		RedCharacterController player;
		float stayTime;
		GrassArea grassArea;
		bool playerTurn = false;
		bool initReady = false;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (inBattle && battleUIPanel != null) {
						//Debug.Log (inBattle);
						//run (battleUIPanel);
						if (!playerTurn && initReady) {
							
						NGUITools.SetActive (battleUIPanel, false);
							

						}	else if (playerTurn && initReady) {
						NGUITools.SetActive (battleUIPanel, true);
						}


				}


				

		}

		public void initWildBattle (GameObject terrainType, Pokemon pokemon, int level, Party partyPkmn, RedCharacterController player, Camera maincCamera, Camera battleCamera, AudioClip music, BattleTerrain battleTerrain, GameObject battleUI, GameObject HUD, float stayTime, GrassArea initiatedFrom)
		{
		roundCounter = 0;
				initReady = false;
				playerTurn = false;
				activePokemon = 0;
				inBattle = true;
				battleUIPanel = battleUI;
				HUDPanel = HUD;
				this.maincCamera = maincCamera;
				this.battleCamera = battleCamera;
				this.player = player;
				this.stayTime = stayTime;
				grassArea = initiatedFrom;
				activePokemonPokemon = (Pokemon)Instantiate (partyPkmn.party [activePokemon]);
				foePokemon = (Pokemon)Instantiate (pokemon);
				Debug.Log (foePokemon.name + ", against " + activePokemonPokemon.name);
				activePokemonPokemon.transform.position = battleTerrain.pokePos1.transform.position;
				foePokemon.transform.position = battleTerrain.pokePos2.transform.position;
				activePokemonPokemon.transform.rotation.Set (activePokemonPokemon.transform.rotation.x, battleTerrain.pokePos1.transform.rotation.eulerAngles.y, activePokemonPokemon.transform.rotation.z, activePokemonPokemon.transform.rotation.w);
				activePokemonPokemon.transform.Rotate (0, battleTerrain.pokePos1.transform.rotation.eulerAngles.y, 0, Space.World);
				foePokemon.transform.rotation.Set (foePokemon.transform.rotation.x, battleTerrain.pokePos2.transform.rotation.y, foePokemon.transform.rotation.z, foePokemon.transform.rotation.w);
				activePokemonPokemon.transform.Rotate (0, battleTerrain.pokePos2.transform.rotation.eulerAngles.y, 0, Space.World);




				foePokemon.getRandomNature ();
				foePokemon.getRandomIVs ();
				foePokemon.Attack = foePokemon.calculateAttack ();
				foePokemon.HP = foePokemon.calculateHP ();
				foePokemon.SpAttack = foePokemon.calculateSpAttack ();
				foePokemon.SpDefense = foePokemon.calculateSpDefense ();
				foePokemon.Speed = foePokemon.calculateSpeed ();
				foePokemon.currentHP = foePokemon.HP;
				activePokemonPokemon.Attack = activePokemonPokemon.calculateAttack ();
				activePokemonPokemon.HP = activePokemonPokemon.calculateHP ();
				activePokemonPokemon.SpAttack = activePokemonPokemon.calculateSpAttack ();
				activePokemonPokemon.SpDefense = activePokemonPokemon.calculateSpDefense ();
				activePokemonPokemon.Speed = activePokemonPokemon.calculateSpeed ();

				
				GameControl ap = player.GetComponent<GameControl> ();
				ap.playScrpt (music);
				maincCamera.GetComponent<Camera> ().enabled = false;
				battleCamera.GetComponent<Camera> ().enabled = true;
				battleCamera.GetComponent<Animation> ().Play ();
				battleTerrain.pokePlayer.GetComponent<Animator> ().SetTrigger ("ThrowPokeball");



				printMessage (new string[]{
			"A wild " + foePokemon.name + " appeared!",
			"What will you do?"	});


		NGUITools.SetActive (battleUI, true);
		NGUITools.SetActive (HUD, false);
		if (battleUI.GetComponentsInChildren<BattleHPBar> () [0].isFoe) {
			healthBarFoe = battleUI.GetComponentsInChildren<BattleHPBar> () [0];
		}
		if (battleUI.GetComponentsInChildren<BattleHPBar> () [1].isFoe) {
			healthBarFoe = battleUI.GetComponentsInChildren<BattleHPBar> () [1];
		}
		if (!battleUI.GetComponentsInChildren<BattleHPBar> () [0].isFoe) {
			healthBarFriend = battleUI.GetComponentsInChildren<BattleHPBar> () [0];
		}
		if (!battleUI.GetComponentsInChildren<BattleHPBar> () [1].isFoe) {
			healthBarFriend = battleUI.GetComponentsInChildren<BattleHPBar> () [1];
		}
		healthBarFoe.setPokemon (foePokemon);
		healthBarFriend.setPokemon (activePokemonPokemon);
		initReady = true;

		playerTurn = true;																//Player´s turn begins here


		}

		public void endBattle ()
		{

				GameControl ap = player.GetComponent<GameControl> ();
				foePokemon = null;
				activePokemonPokemon = null;
				ap.playScrpt (grassArea.GetComponentInParent<Location> ().music);
				inBattle = false;
				NGUITools.SetActive (battleUIPanel, false);
				NGUITools.SetActive (HUDPanel, true);
				battleCamera.GetComponent<Animation> ().Stop ();
				battleCamera.GetComponent<Camera> ().enabled = false;
				maincCamera.GetComponent<Camera> ().enabled = true;
				grassArea.stayTime = Time.time + grassArea.frequency + 5;


		}

		public int calculateExpPoints (Party party, bool isWildBattle, Pokemon xpForPokemon)
		{
				float a;
				if (isWildBattle) {
						a = 1f;
				} else {
						a = 1.5f;
				}
				float b = foePokemon.expYield;
				float e;
				if (party.party [activePokemon].heldItem.name == "Lucky Egg") {
						e = 1.5f;
				} else {
						e = 1f;
				}
				float f = 1f;
				float L = foePokemon.level;
				float Lp = party.party [activePokemon].level;
				float p = 1f;
				float s = 1f;
				float t = 1f;
				float v = 1f;
				float EXP = 0;
				float help1;
				float help2;
				float help12;
				float help3;
				float help4;
				float help34;
				float help1234;
				help1 = a * b * L;
				help2 = 5 * s;
				help12 = help1 / help2;
				help3 = Mathf.Pow (2 * L + 10, 2.5f);
				help4 = Mathf.Pow (L + Lp + 10, 2.5f);
				help34 = (help3 / help4) + 10;
				help1234 = help12 * help34 + 1;
				EXP = help1234 * t * e * p;
				return Mathf.RoundToInt (EXP);

		}

		public void run ()
		{
				bool canRun = false;
				//if (battleUI.GetComponentInChildren<Run> ().running) {
						if (activePokemonPokemon.level < foePokemon.level) {
								if (Random.Range (1, 100) <= 40) {
										canRun = true;
								}
						}
						if (activePokemonPokemon.level == foePokemon.level) {
								if (Random.Range (1, 100) <= 55) {
										canRun = true;
								}
						}
						if (activePokemonPokemon.level > foePokemon.level) {
								if (Random.Range (1, 100) <= 75) {
										canRun = true;
								}
						}
						//Debug.Log(canRun);
						if (canRun) {
								//battleUI.GetComponentInChildren<Run> ().running = false;
								endBattle ();
						}
						else {
					opponentsRound();				
		}
				//}



		}

		public void attack(){

		}

	public void changePokemon(){
		
	}

	public void bag(){
		
	}

		public void playersRound (){





		opponentsRound();
		}

		public void opponentsRound ()
		{
				if (foePokemon.currentHP <= foePokemon.HP) {
						//Check for item in bag here

						//Use item here
						return;
				}
				//if (canOpponentRun) {
				//Add this boolean to Pokemon class
				//		}


				//Attack mechanic here. Create attacks first (at least four)
		endRound();
		}

		public void endRound(){
		roundCounter++;
		}

		public void printMessage (string[] message)
		{

				NGUITools.SetActive (messageBox, true);
				messageBoxBackground.messages = message;
				messageBoxBackground.messageCount = message.Length;
				messageBoxBackground.currentMessage = 1;
				messageBoxLabel.text = message [0];
		}




}
