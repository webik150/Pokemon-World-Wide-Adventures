using UnityEngine;
using System.Collections;

public class EXPTypeFast : EXPType {


	public override int getLevel(Pokemon pokemon){
		int currentExp = pokemon.currentExp;
		int expHelper1 = 0;
		int expToNextLevel = 0;
		int level = 0;
		
		
		
		while (currentExp <= expHelper1) {
			level++;
			expHelper1 = calculateEXP(level+1);
			
		}
		expToNextLevel = expHelper1 - currentExp;
		
		
		return level;
	}
	public override int calculateEXP(int level){
		return 4*level*level*level/5;
	}
}
