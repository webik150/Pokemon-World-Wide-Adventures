using UnityEngine;
using System.Collections;

public class GrassArea : MonoBehaviour {

	public float frequency = 5f;
	public float randomness = 2f;
	public BattleTerrain battleTerrain;
	public RedCharacterController player;
	public Party playerparty;
	public GameObject terrainType;
	public Pokemon[] meetablePokemon;
	public GameObject BattleUI;
	public GameObject HUD;
	public int[] minLvl;
	public int[] maxLvl;
	public Camera mainCamera;
	public Camera battleCamera;
	public AudioClip music;
	public BattleFieldSystem bf;
	public float stayTime;
	int pokeid;

	void Start(){
	}
	
	// Any time you call this function, it will return true if the character
	// has moved 1 milimeter or more since the last time the function was called



	
	// Update is called once per frame
	void OnTriggerEnter (Collider coll){
		stayTime = Time.time + frequency + Random.Range(-randomness,randomness);
	}


	void OnTriggerStay (Collider coll) {

		if (Time.time > stayTime && coll.CompareTag("Player")&& !bf.inBattle) {
			stayTime = Time.time + frequency + Random.Range(-randomness,randomness);
			bf.initWildBattle(terrainType, selectRandomPokemon(), this.selectRandomLvl(pokeid),playerparty, player,mainCamera,battleCamera,music,battleTerrain,BattleUI,HUD, stayTime,this);
				}



	}

	public GrassArea ()
	{
	}
	float Frequency {
		get {
			return this.frequency;
		}
		set {
			frequency = value;
		}
	}

	Party Playerparty {
		get {
			return this.playerparty;
		}
		set {
			playerparty = value;
		}
	}

	GameObject TerrainType {
		get {
			return this.terrainType;
		}
		set {
			terrainType = value;
		}
	}

	Pokemon[] MeetablePokemon {
		get {
			return this.meetablePokemon;
		}
		set {
			meetablePokemon = value;
		}
	}

	int[] MinLvl {
		get {
			return this.minLvl;
		}
		set {
			minLvl = value;
		}
	}

	int[] MaxLvl {
		get {
			return this.maxLvl;
		}
		set {
			maxLvl = value;
		}
	}

	public Pokemon selectRandomPokemon(){
		int x = Random.Range(0,meetablePokemon.Length-1);

		pokeid = x;
		return meetablePokemon[x];
	}



	public int selectRandomLvl(int ID){
		return Random.Range(minLvl[ID],maxLvl[ID]);
	}
}
