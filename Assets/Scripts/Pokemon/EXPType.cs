using UnityEngine;
using System.Collections;

public abstract class EXPType : MonoBehaviour {



	public abstract int getLevel(Pokemon pokemon);

	public abstract int calculateEXP(int level);



}
