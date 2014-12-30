using UnityEngine;
using System.Collections;

public class TVNoise : MonoBehaviour {
	public Material mat1;
	public int materialID;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<MeshRenderer>().materials[materialID].mainTextureOffset = new Vector2(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f));
	}
}
