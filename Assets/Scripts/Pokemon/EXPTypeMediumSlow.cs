using UnityEngine;
using System.Collections;

public class EXPTypeMediumSlow : EXPType {


	public override int getLevel(Pokemon pokemon){
		int currentExp = pokemon.currentExp;
		int expHelper1 = 0;
		int expToNextLevel = 0;
		int level = 0;
		
		
		
		while (expHelper1 <= currentExp) {
			level++;
			expHelper1 = calculateEXP(level+1);
			
		}
		expToNextLevel = expHelper1 - currentExp;
		
		//Debug.Log(level);
		return level;
	}
	public override int calculateEXP(int level){
		double helper1 = 0;
		double helper2 = 0;


		helper1 = (6/5)*(level*level*level);
		helper2 = helper1 - 15*(level*level) + 100*level - 140;
		//Debug.Log(helper2);
		return (int)helper2;
	}
}
