using UnityEngine;
using System.Collections;

public class SpawnTest : MonoBehaviour {
	
	public GameObject whattospawn;
	public GameObject wheretospawn;
	public int howmany;


	void Start () {

	for (int i = 0; i < howmany; i++) {
			Instantiate(whattospawn,new Vector3(wheretospawn.transform.position.x,wheretospawn.transform.position.y+i*2,wheretospawn.transform.position.z), Quaternion.identity);
				}
	}
}
