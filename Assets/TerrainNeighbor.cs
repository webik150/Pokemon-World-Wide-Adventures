using UnityEngine;
using System.Collections;

public class TerrainNeighbor : MonoBehaviour {

	
	public Terrain left;
	public Terrain right;
	public Terrain bottom;
	public Terrain top;


	// Use this for initialization
	void Start () {
		GetComponent<Terrain>().SetNeighbors(left,top,right,bottom);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
