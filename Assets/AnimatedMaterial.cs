using UnityEngine;
using System.Collections;

public class AnimatedMaterial : MonoBehaviour {


	public Texture[] frames;
	public int speed = 1;
	public int materialID = 0;
	private int index = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	for (int i = 0; i <= speed; i++) {
		if (i == speed) {
				GetComponent<MeshRenderer>().materials[materialID].mainTexture = frames[index];
				index++;
				if (index >= frames.Length) {
					index = 0;
				}
		}
				}
	}
}
