using UnityEngine;
using System.Collections;

public class EXPTypeErratic : EXPType {


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
		double helper1 = 0;
		double helper2 = 0;
		if (level < 0) {
			return 0;
				}
		if (level == 0) {
			return 0;
				}
		if (level <= 50) {										//0-50
			return level*level*level*(100-level)/50;
				}
		if (level > 50 && level <= 68) {									//51-68
			return level*level*level*(150-level)/100;
				}
		if (level > 68 && level <= 98) {
			helper1 = 1911-level*10/3;
			helper2 = level*level*level*helper1/500;
			return  (int)helper2;
				}
		if (level > 97 && level <= 100) {
			return level*level*level*(160-level)/100;
				}
		return 0;
	}
}
