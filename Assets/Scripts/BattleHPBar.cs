using UnityEngine;
using System.Collections;

public class BattleHPBar : MonoBehaviour {

	public bool isFoe;
	public UILabel maxHPLabel;
	public UILabel currentHPLabel;
	public UISprite HPBar;
	public UISprite pkmnSprite;
	Pokemon pokemon;
	int barSize;



	void Start () {
	
	}
	

	void Update () {
		if (pokemon != null) {
			maxHPLabel.text = "/"+pokemon.HP.ToString();
			currentHPLabel.text = pokemon.currentHP.ToString();
			UpdateSize();
			UpdateColours();
			//pokemonSprite.atlas = spriteAtlas;
			pkmnSprite.spriteName = pokemon.ID.ToString();
			pkmnSprite.aspectRatio = 2;
		}
		else{
			pkmnSprite.spriteName = "0";
			maxHPLabel.text = "/???";
			currentHPLabel.text = "???";
		}
	}
	void UpdateSize(){
		barSize = pokemon.currentHP * 224 / pokemon.HP;
		HPBar.width = barSize;
		//Debug.Log(barSize);
	}


	public void setPokemon(Pokemon pokemon){
		this.pokemon = pokemon;
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
