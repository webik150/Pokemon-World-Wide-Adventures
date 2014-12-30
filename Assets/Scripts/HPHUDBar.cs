using UnityEngine;
using System.Collections;

public class HPHUDBar : MonoBehaviour {


	public int pokemonPartyID;
	public UILabel MaxHP;
	public UILabel CurrentHP;
	public UISprite HPBar;
	public UISprite pkmnSprite;
	UISprite pokemonSprite;
	public UIAtlas spriteAtlas;

	public UISprite EXPFill;

	Pokemon pokemon;
	int hpBarSize;
	int expBarSize;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Party>().party[pokemonPartyID]) {
			pokemon = GameObject.FindGameObjectWithTag("Player").GetComponent<Party>().party[pokemonPartyID];
			MaxHP.text = "/"+pokemon.calculateHP().ToString();
			CurrentHP.text = pokemon.currentHP.ToString();
			UpdateSize();
			UpdateColours();
			//pokemonSprite.atlas = spriteAtlas;
			pkmnSprite.spriteName = pokemon.ID.ToString();
			pkmnSprite.aspectRatio = 1;
				}
		else{
			pkmnSprite.spriteName = "0";
			MaxHP.text = "/???";
			CurrentHP.text = "???";
			UpdateSize();
			//UpdateColours();
		}



	}
	void UpdateSize(){
		if (GameObject.FindGameObjectWithTag("Player").GetComponent<Party>().party[pokemonPartyID]) {
		hpBarSize = pokemon.currentHP * 100 / pokemon.calculateHP();
		HPBar.width = hpBarSize;
			if (pokemon.currentExp >= 8) {
				expBarSize = (pokemon.currentExp - pokemon.getEXPForThisLevel()+1) * 219 / (pokemon.getEXPForNextLevel()-pokemon.getEXPForThisLevel());
			} else {
				expBarSize = pokemon.currentExp * 219 / pokemon.getEXPForNextLevel();
			}
		
			Debug.Log(expBarSize);
		EXPFill.width = expBarSize;
		}
		else {
			hpBarSize = 0 * 100 / 100;
			expBarSize = 0 * 219 / 219;
			HPBar.width = hpBarSize;
			EXPFill.width = expBarSize;
				}
		//Debug.Log(barSize);
	}
	void UpdateColours(){
		if (pokemon.currentHP > pokemon.HP/2) {
			HPBar.color = Color.green;
				}
		if (pokemon.currentHP <= pokemon.HP/2 && pokemon.currentHP > pokemon.HP/5) {
			HPBar.color = Color.yellow;
				}
		if (pokemon.currentHP <= pokemon.HP/5) {
			HPBar.color = Color.red;
		}
	}
}
