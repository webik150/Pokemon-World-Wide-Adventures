using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace FullInspector {
public class MenuCamera : MonoBehaviour {

	public Camera mainCamera;
	public Transform EoV;
	public GameObject[] objects;

	void Start () {
		StartCoroutine("SelectPlanet");
	}
	
	IEnumerator SelectPlanet() {
		//Debug.Log("Logstart");
		CameraFollow cf = mainCamera.GetComponent<CameraFollow>();
		cf.distance = 12;
		cf.target = EoV;
		//Debug.Log("Log1");
		yield return new WaitForSeconds(5);
		//Debug.Log("Log2");
		for (int i = 0; i < objects.Length; i++) {
			//Debug.Log("Log3");

			cf.target = objects[i].transform;
			cf.height = Random.Range(3,5);
			cf.distance = Random.Range(5,10);
			Debug.Log(cf.distance);
			yield return new WaitForSeconds(8.0F);
				if (i>=objects.Length-1) {
					Start ();
				}
			}
		yield break;
	}

	void Update () {
	}
	}
}