using UnityEngine;
using System.Collections;

public class DayNightWater : MonoBehaviour {

	private UniStormWeatherSystem_C uniStormSystem;
	public float duration = 5f;
	private float lerpControl = 0f;
	public float nightHour = 17;
	public float dayHour = 6;
	public Color colorDay;
	public Color colorNight;
	public Color currentColor;
	public bool colorIsDay = true;
	public bool colorIsNight = false;

	void Awake () {
		
		//Find the UniStorm Weather System Editor, this must match the UniStorm Editor name
		uniStormSystem = GameObject.Find("UniStormSystemEditor").GetComponent<UniStormWeatherSystem_C>();

	}
	
	void Start () {
		
		if (uniStormSystem == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Null Reference:</color> You must have the UniStorm Editor in your scene and named 'UniStormSystemEditor'. Make sure your C# UniStorm Editor has this name. ");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		currentColor = renderer.material.color;
		float secondcounter = (float)uniStormSystem.minuteCounter+1;
		if (uniStormSystem != null)
		{
			
			if ((uniStormSystem.hourCounter >= nightHour || uniStormSystem.hourCounter <= dayHour) && colorIsDay)
			{
				renderer.material.color = Color.Lerp(colorDay,colorNight,secondcounter/60);

			}
			else {
				if ((uniStormSystem.hourCounter < nightHour && uniStormSystem.hourCounter > dayHour) && colorIsNight) {
					renderer.material.color = Color.Lerp(colorNight,colorDay,secondcounter/60);

				}
			}
			if (renderer.material.color == colorDay) {
				colorIsDay = true;
				colorIsNight = false;
			}
			if (renderer.material.color == colorNight) {
				colorIsDay = false;
				colorIsNight = true;
			}
		}



	}
}
