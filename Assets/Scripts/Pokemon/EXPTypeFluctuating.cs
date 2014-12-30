using UnityEngine;
using System.Collections;

public class EXPTypeFluctuating : EXPType {


	public override int getLevel(Pokemon pokemon){
		int currentExp = pokemon.currentExp;
		int expHelper1 = 0;
		int expToNextLevel = 0;
		int level = 0;
		
		
		
		while (currentExp < expHelper1) {
			level++;
			expHelper1 = calculateEXP(level+1);
			
		}
		expToNextLevel = expHelper1 - currentExp;
		
		
		return level;
	}
	public override int calculateEXP(int level){
		double helper1 = 0;
		double helper2 = 0;
		double helper3 = 0;

		if (level <= 0) {
			return 0;
				}
		if (level <= 15) {
			helper1 = (level+1)/3;
			helper2 = (helper1+24)/50;
			helper3 = level*level*level*helper2;
			return (int)helper3;
				}
		if (level > 15 && level <= 36) {
			helper1 = (level+14)/50;
			helper2 = level*level*level*helper1;
			return (int)helper2;
				}
		if (level > 16 && level <= 100) {
			helper1 = level/2;
			helper2 = (helper1+32)/50;
			helper3 = level*level*level*helper2;
			return (int)helper3;
		}
		return 0;


	}
}
