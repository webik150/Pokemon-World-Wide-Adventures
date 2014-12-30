using UnityEngine;
using System.Collections;

public class Pokemon : MonoBehaviour{

	public int ID;
	public PokemonType type;
	public PokemonType type2;
	public string name;
	public string nickname;
	public HeldItem heldItem;
	public int currentExp;
	public int level;
	public int EXPtoNextLvl;
	public string expType;
	public EXPType realEXPType;
	public int expYield;
	public int EV;
	public string EVStat;
	public Nature nature;
	public int currentHP;
	public int HP;
	public int Attack;
	public int Defense;
	public int SpAttack;
	public int SpDefense;
	public int Speed;
	public int BaseHP;
	public int BaseAttack;
	public int BaseDefense;
	public int BaseSpAttack;
	public int BaseSpDefense;
	public int BaseSpeed;
	public int IVHP;
	public int IVAttack;
	public int IVDefense;
	public int IVSpAttack;
	public int IVSpDefense;
	public int IVSpeed;
	int IVTotal;


//	public Pokemon (int ID,string name, int HP, int Attack, int Defense, int SpAttack, int SpDefense, int Speed){
//		this.ID = ID;
//		this.name = name;
//		this.HP = HP;
//		this.Attack = Attack;
//		this.Defense = Defense;
//		this.SpAttack = SpAttack;
//		this.SpDefense = SpDefense;
//		this.Speed = Speed;
//		this.Total = HP+Attack+Defense+SpDefense+SpAttack+Speed;
//	}
	void Update(){
		if (currentHP > HP) {
			currentHP = HP;
				}
		if (GetComponent<GivePokemon>()) {
			return;
				}
		IVTotal = IVAttack+IVDefense+IVSpAttack+IVSpDefense+IVHP+IVSpeed;
		calculateStuff ();
		if (realEXPType == null) {
			getEXPType();
				}

	}
	public void getEXPType(){
		realEXPType = GameObject.Find(expType).GetComponent<EXPType>();
		Debug.Log(realEXPType);
	}
	public void getRandomNature(){
		nature = GameObject.Find("NatureDB").GetComponent<NatureDB>().natures[Random.Range(0,24)];
		Debug.Log(nature.name);
	}
	public void Heal () {
		currentHP = HP;
	}
	public void Heal(int howMuch){
		if (currentHP+howMuch >= HP){
			currentHP += howMuch;
		}
		else{
			if(currentHP+howMuch<HP){
				currentHP = HP;
			}
		}
	}
	public void getRandomIVs(){
		IVHP = Random.Range(0,31);
		IVAttack = Random.Range(0,31);
		IVSpAttack = Random.Range(0,31);
		IVDefense = Random.Range(0,31);
		IVSpDefense = Random.Range(0,31);
		IVSpeed = Random.Range(0,31);

	}
	public void calculateStuff(){
		HP = calculateHP();
		Attack = calculateAttack();
		Defense = calculateDefense();
		SpAttack = calculateSpAttack();
		SpDefense = calculateSpDefense();
		Speed = calculateSpeed();
	}
	public int calculateHP(){
		return (BaseHP * 2 + IVHP + (EV/4)) * level / 100 + 10 + level;
	}
	public int calculateAttack(){
		return (((BaseAttack * 2 + IVAttack + (EV/4)) * level / 100 + 5)*nature.Attack)/100;
	}
	public int calculateDefense(){
		return (((BaseDefense * 2 + IVDefense + (EV/4)) * level / 100 + 5)*nature.Defense)/100;
	}
	public int calculateSpAttack(){
		return (((BaseSpAttack * 2 + IVSpAttack + (EV/4)) * level / 100 + 5)*nature.SpAttack)/100;
	}
	public int calculateSpDefense(){
		return (((BaseSpDefense * 2 + IVSpDefense + (EV/4)) * level / 100 + 5)*nature.SpDefense)/100;
	}
	public int calculateSpeed(){
		return (((BaseSpeed * 2 + IVSpeed + (EV/4)) * level / 100 + 5)*nature.Speed)/100;
	}
	// Use this for initialization
	void Start () {
	
	}
	public int getLevel(){
		return level = realEXPType.getLevel(this);
	}
	public int getEXPOnLevel(int level){
		return realEXPType.calculateEXP(level);
	}
	public int getEXPForNextLevel(){
		return realEXPType.calculateEXP(getLevel()+1);
	}
	public int getEXPForThisLevel(){
		return realEXPType.calculateEXP(getLevel());
	}
	public int getEXPForPrevLevel(){
		if (level != 1) {
			return realEXPType.calculateEXP(getLevel()-1);
				}
		return 0;
	}
}
